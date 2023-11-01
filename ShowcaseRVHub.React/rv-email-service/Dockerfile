# Use an official Node.js runtime as the base image for the build stage
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

# Use an official Nginx image as the base image for the final production build
FROM nginx:alpine

# Remove the default Nginx configuration file
RUN rm /etc/nginx/nginx.conf

# Copy custom Nginx configuration
COPY nginx/nginx.conf /etc/nginx/nginx.conf

# Copy the built React app from the build stage to the Nginx web root
COPY --from=build /app/build /usr/share/nginx/html

# Expose the port the Nginx server will listen on
EXPOSE 80

# Start Nginx to serve the React app
CMD ["nginx", "-g", "daemon off;"]
