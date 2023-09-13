# Use the official Node.js image as a base image for the React client
FROM node:14 AS react-client

# Set the working directory for the React client
WORKDIR /app

# Copy the React client source code
COPY . .

# Install dependencies and start the React app
RUN npm install
CMD ["npm", "start"]
