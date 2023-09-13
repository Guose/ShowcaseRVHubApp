# Use the official Node.js image as a base image for the Express.js server
FROM node:14 AS express-server

# Set the working directory for the Express.js server
WORKDIR /app

# Copy the Express.js server source code
COPY . .

# Install dependencies and start the Express.js server
RUN npm install
CMD ["npm", "run", "dev"]
