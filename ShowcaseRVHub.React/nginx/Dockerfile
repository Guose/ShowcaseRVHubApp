# Use the official Nginx image as the base image
FROM nginx:alpine

# Copy custom Nginx configuration
COPY nginx.conf /etc/nginx/nginx.conf

# Copy your React app build to the Nginx web root
COPY ./build /usr/share/nginx/html

# Expose port 80
EXPOSE 80
