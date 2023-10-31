# Use the official Node.js image as a base image for the React client
FROM node:16.17.0-bullseye-slim AS build

# Set the working directory for the React client
WORKDIR /app

# Copy the package.json and package-lock.json to the container
COPY package*.json ./

# Build the React client
# Install dependencies for React client
RUN npm install

# Copy the React client source code
COPY . .

RUN npm run build

# Stage 2: Create a runtime image
FROM nginx:alpine AS final

# Copy the build application from the build stage
COPY --from=build /app/build /usr/share/nginx/html
#RUN cp /app/build/index.html /app/public/index.html

# Expose the port on which application will listen
EXPOSE 3000

# Command to start the Nginx server
CMD ["nginx", "-g", "daemon off;"]