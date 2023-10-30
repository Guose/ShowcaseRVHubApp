# Use the official Node.js image as a base image for the React client
FROM node:latest AS build

# Set the working directory for the React client
WORKDIR /app

# Copy the package.json and package-lock.json to the container
COPY ["app/package.json", "app/package-lock.json", "./"]

# Install dependencies for React client
RUN npm install

# Copy the React client source code
COPY . .

# Build the React client
RUN npm run build

# Stage 2: Create a runtime image
FROM node:latest AS final

# Set the working directory for the React client
WORKDIR /app

# Copy the build application from the build stage
COPY --from=build /app/build ./build

# Expose the port on which application will listen
EXPOSE 3000

CMD ["npm", "start"]