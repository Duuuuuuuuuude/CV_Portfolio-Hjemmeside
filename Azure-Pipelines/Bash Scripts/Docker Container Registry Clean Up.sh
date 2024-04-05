#!/bin/bash

min_to_keep=10
delete_days_old=3
verbose=yes

# Gets all tags in repository
response=$(curl --silent \
                --write-out "HTTPSTATUS:%{http_code}" \
                -X GET \
                -H "Content-Type: application/json" \
                -H "Authorization: Bearer "$bearerTokenContainerRegistry"" \
                ""$containerRegistryAPIBaseURL"/repositories/"$repositoryNameURLEncoded"/tags?per_page=200")

# Separates the JSON response from the HTTP status
http_status=$(echo $response | tr -d '\n' | sed -e 's/.*HTTPSTATUS://')
json_response=$(echo $response | sed -e 's/HTTPSTATUS\:.*//g')

# Checks the HTTP status code and exits if the HTTP request failed. Also prints out the json body, if it failed and message if there was nothing to delete
if [ $http_status -eq 404 ]; then
    echo "Error: HTTP response $http_status"
    if [[ "$verbose" == "yes" ]]; then
      echo "Nothing to delete"
    fi
    exit 0
elif [ $http_status -ne 200 ]; then
    echo "Error: HTTP response $http_status"
    echo "Response body: $json_response"
    exit 1
fi


# echo $json_response | jq -r ".tags[]" # SLET


date_boundary=$(date -d"-$delete_days_old days" +%s)
# Get all tags
all_tags=$(echo $json_response | jq ".[] | select ( .updated_at | fromdateiso8601 < $date_boundary) | .tag " -r | tr '\n' ' ')

# Get the number of tags
# num_tags=$(echo $all_tags | jq '. | length')
num_tags=$(echo $all_tags | jq -s 'split(" ") | length')


# Check if there are at least min_to_keep tags
if (( num_tags > min_to_keep )); then
  # Get all tags except the first min_to_keep
  deletable_tags=$(echo $all_tags | .[$min_to_keep:])
else
  echo "There are fewer than $min_to_keep tags. No tags will be deleted."
  exit 0
fi


# Check the exit status of jq for errors
if [ $? -ne 0 ]; then
    echo "Error: jq command failed"
    exit 1
fi
      
[[ "$verbose" == "yes" ]] && {
  echo "DELETING images in the container registry, that are more than $delete_days_old days"
  echo "While KEEPING at least $min_to_keep of the newest images in the container registry"
  echo ""
  echo "Tags from the images being deleted:"
  echo "Deleteable tags: $deletable_tags"
}

# Tags being deleted on the images in container registry.
for tag in $deletable_tags; do
  response=$(curl --silent \
                  --write-out "HTTPSTATUS:%{http_code}" \
                  -X DELETE \
                  -H "Content-Type: application/json" \
                  -H "Authorization: Bearer "$bearerTokenContainerRegistry"" \
                  ""$containerRegistryAPIBaseURL"/repositories/"$repositoryNameURLEncoded"/tags/$tag")

  # Separate the JSON response from the HTTP status
  http_status=$(echo $response | tr -d '\n' | sed -e 's/.*HTTPSTATUS://')
  json_response=$(echo $response | sed -e 's/HTTPSTATUS\:.*//g')

  # Checks the HTTP status error codes
  if [$http_status -eq 404] && [[ "$verbose" == "yes" ]]; then
    echo "Response body: $json_response"
  fi

  if [ $http_status -ne 200 ] && [ $http_status -ne 404]; then
    echo "Error: HTTP response $http_status"
    echo "Response body: $json_response"
    exit 1
  fi
done

                # This will run a garbage collection and delete images no longer used and untagged images.
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