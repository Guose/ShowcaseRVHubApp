# Use the official Node.js image as a base image for the Express.js server
FROM node:latest AS build

# Set the working directory for the Express.js server
WORKDIR /app

# Copy the package.json and package-lock.json to the container
COPY app/package*.json ./

# Install dependencies for Express.js server
RUN npm install

# Copy the Express.js server source code
COPY . .

# Build the Express.js server
RUN npm run build

# Stage 2: Create a runtime image
FROM node:latest AS final

# Set the working directory for the Express.js server
WORKDIR /app

# Copy the build application from the build stage
COPY --from=build /app/build ./build

# Expose the port on which application will listen
EXPOSE 3001

CMD ["npm", "start"]
