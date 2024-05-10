# concierge
A simple concierge service wrapper for OpenAI's "Create chat completion" API deployed as a container

# Pre-requisites (after you git clone this project)
cd concierge <BR>
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

# To run the service
curl -X POST \ <BR>
  -H "Content-Type: application/json" \ <BR>
  -d '{"prompt": "Can you suggest a message I can send to my customer who needs a botox appointment?"}' \ <BR>
  http://localhost:8080/generateChatCompletion <BR>

