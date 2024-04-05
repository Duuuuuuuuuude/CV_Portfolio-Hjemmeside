#!/bin/bash
# Inspired by: https://laimis.medium.com/net-web-apps-on-digitalocean-85f0c3acd57f

min_to_keep=10
delete_days_old=3
verbose=yes


run_garbage_collection() {
  echo 'Activating garbage collection.'
  # This will run a garbage collection and delete images no longer used and untagged digest.
  response=$(curl --silent \
                  --write-out "HTTPSTATUS:%{http_code}" \
                  -X POST \
                  -H "Content-Type: application/json" \
                  -H "Authorization: Bearer "$bearerTokenContainerRegistry"" \
                  ""$containerRegistryAPIBaseURL"/garbage-collection")


  # Separate the JSON response from the HTTP status
  http_status=$(echo $response | tr -d '\n' | sed -e 's/.*HTTPSTATUS://')
  json_response=$(echo $response | sed -e 's/HTTPSTATUS\:.*//g')

  # Checks the HTTP status error codes
  if [ $http_status -ne 201 ]; then
    echo "Error: HTTP response $http_status"
    echo "Response body: $json_response"
    exit 1
  fi
}


# Gets all Container Registry Repository Manifest in repository
response=$(curl --silent \
                --write-out "HTTPSTATUS:%{http_code}" \
                -X GET \
                -H "Content-Type: application/json" \
                -H "Authorization: Bearer "$bearerTokenContainerRegistry"" \
                ""$containerRegistryAPIBaseURL"/repositories/"$repositoryNameURLEncoded"/digests?per_page=200")

# Separates the JSON response from the HTTP status
http_status=$(echo $response | tr -d '\n' | sed -e 's/.*HTTPSTATUS://')
json_response=$(echo $response | sed -e 's/HTTPSTATUS\:.*//g')

# Checks the HTTP status code and exits if the HTTP request failed.
#if [ $http_status -eq 404 ]; then
#    echo "Error: HTTP response $http_status"
#    if [[ "$verbose" == "yes" ]]; then
#      echo "Nothing to delete"
#    fi
#    exit 0
#el
if [ $http_status -ne 200 ]; then
    echo "Error: HTTP response $http_status"
    echo "Response body: $json_response"
    exit 1
fi

# echo $json_response | jq -r ".tags[]" # DEBUG CODE
# echo "$json_response" | jq # DEBUG CODE

# Filters by delete_days_old and min_to_keep
date_boundary=$(date -d-"$delete_days_old days" +%s)
deletable_digests=$(echo $json_response | jq ".manifests[$min_to_keep:] | .[] | select ( .updated_at | fromdateiso8601 < $date_boundary) | .digest " -r | tr '\n' ' ')

# Check the exit status of jq for errors
if [ $? -ne 0 ]; then
    echo "Error: jq command failed"
    exit 1
fi

[[ -z "$deletable_digests" ]] && {
  [[ "$verbose" == "yes" ]] && echo "Nothing to delete"
  run_garbage_collection
  exit 0
}
      
[[ "$verbose" == "yes" ]] && {
  echo "DELETING images in the container registry, that are more than $delete_days_old days old"
  echo "While KEEPING at least $min_to_keep of the newest images in the container registry"
  echo ""
  echo "Deleteable digests: $deletable_digests"
  echo ""
}

# digests being deleted in the container registry.
for digest in $deletable_digests; do
  response=$(curl --silent \
                  --write-out "HTTPSTATUS:%{http_code}" \
                  -X DELETE \
                  -H "Content-Type: application/json" \
                  -H "Authorization: Bearer "$bearerTokenContainerRegistry"" \
                  ""$containerRegistryAPIBaseURL"/repositories/"$repositoryNameURLEncoded"/digests/$digest")

  # Separate the JSON response from the HTTP status
  http_status=$(echo $response | tr -d '\n' | sed -e 's/.*HTTPSTATUS://')
  json_response=$(echo $response | sed -e 's/HTTPSTATUS\:.*//g')

  # Checks the HTTP status error codes
  if [$http_status -eq 404] && [[ "$verbose" == "yes" ]]; then
    echo "Error: HTTP response $http_status"
    echo "Response body: $json_response"
  fi

  if [ $http_status -ne 204 ] && [ $http_status -ne 404]; then
    echo "Error: HTTP response $http_status"
    echo "Response body: $json_response"
    exit 1
  fi
done

run_garbage_collection