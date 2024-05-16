# First stage: Build environment
FROM node:14 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install dependencies
RUN npm install --only=production

# Copy the application code to the working directory
COPY . .

# Second stage: Production environment
FROM node:14-slim

# Set the working directory inside the container
WORKDIR /app

# Copy only the necessary files from the previous stage
COPY --from=build /app .

# Expose port 3000 (or the port your application listens on)
EXPOSE 3000

# Command to run the application
CMD ["node", "index.js"]

