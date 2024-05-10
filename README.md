# concierge
A simple concierge service wrapper for OpenAI's Create chat completion API deployed as a docker container

# Pre-requisites
npm init -y <BR>
npm install axios --save <BR>
npm install express --save <BR>
npm install body-parser --save <BR>

Validate existence of package*.json 

# Docker/Podman commands to run
docker build -t concierge-wrapper .

# Ensure that you have a valid OPEN_AI Key
docker run -d --name concierge-service -p 8080:3000 -e OPENAI_API_KEY=<YOUR OPENAI KEY HERE> concierge-wrapper

# Ensure that the service is up
docker logs --tail all concierge-service
