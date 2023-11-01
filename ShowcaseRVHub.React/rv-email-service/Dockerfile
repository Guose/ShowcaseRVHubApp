# Use an official Node.js runtime as the base image
FROM node:18.12.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy package.json and package-lock.json to the container
COPY package*.json ./

# Install project dependencies
RUN npm install

# Copy the rest of the application code to the container
COPY . .

# Build the React app
RUN npm run build

# Use a smaller base image for the final production build
FROM nginx:alpine

# Copy the built React app from the build stage to the nginx web root
COPY --from=build /app/build /usr/share/nginx/html

# Expose the port the Nginx server will listen on
EXPOSE 80

# Start Nginx to serve the React app
CMD ["nginx", "-g", "daemon off;"]
