# concierge-dotnet-service
A simple concierge service wrapper for OpenAI's "Create chat completion" API deployed as a .NET container

# Pre-requisites (after you git clone this project)
cd concierge/service/OpenAIWrapper <BR>

# Docker/Podman commands to run
docker build -t openai-wrapper .

# Ensure that you have a valid OPEN_AI Key
docker run -d --name concierge-dotnet-service -e OpenAI__ApiKey='YOUR OPENAI KEY HERE' -p 9080:80 openai-wrapper

# Ensure that the service is up
docker logs --tail all concierge-dotnet-service

# To run the service
curl -X POST \ <BR>
  -H "Content-Type: application/json" \ <BR>
  -d '{"prompt": "Can you suggest a message I can send to my customer who needs a botox appointment?"}' \ <BR>
  http://localhost:9080/concierge/generateChatCompletion <BR>
