          #!/bin/bash

          retries=20
          seconds_between_retries=20

          # Gets active garbage collection
          for ((i=1; i<=retries; i++))
          do
            echo "Getting active garbage collection"
            echo
            response=$(curl --silent \
                            --write-out "HTTPSTATUS:%{http_code}" \
                            -X GET \
                            -H "Content-Type: application/json" \
                            -H "Authorization: Bearer "$(bearerTokenContainerRegistry)"" \
                            ""$(containerRegistryAPIBaseURL)"/garbage-collection")
                                
            # Separate the JSON response from the HTTP status
            http_status_code=$(echo $response | tr -d '\n' | sed -e 's/.*HTTPSTATUS://')
            json_response=$(echo $response | sed -e 's/HTTPSTATUS\:.*//g')

            # Checks the HTTP status error codes
            if [ $http_status_code -eq 404 ]; then
              echo "HTTP status code: $http_status_code"
              echo "No active garbage collection found. Continuing to image push task."
              echo "Response body: $json_response"
              echo
              exit 0

            elif [ $http_status_code -eq 200 ]; then
              echo "HTTP status code: $http_status_code"
              echo "Response body: $json_response"
              echo "Can't push image when there is an active garbage collection running. Trying again in $seconds_between_retries seconds."
              
              for ((j=1; j<=seconds_between_retries; j++))
              do
                sleep 1
              done
              echo
              echo

            else
              echo "HTTP status code: $http_status_code"
              echo "Response body: $json_response"
              echo
            fi

          done