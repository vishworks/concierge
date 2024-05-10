# Dockerfile

# Use the official Node.js image as the base image
FROM node:14

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the application code to the working directory
COPY . .

# Expose port 3000 (or the port your application listens on)
EXPOSE 3000

# Command to run the application
CMD ["node", "index.js"]
