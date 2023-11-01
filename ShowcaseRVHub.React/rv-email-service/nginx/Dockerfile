# Use the official Nginx image as the base image
FROM nginx:alpine

# Remove the default Nginx configuration file
RUN rm /etc/nginx/conf.d/default.conf

# Remove the default Nginx configuration file
RUN rm /etc/nginx/nginx.conf

# Copy your custom Nginx configuration file to the container
COPY nginx.conf /etc/nginx/conf.d/

# # Copy custom Nginx configuration
# COPY nginx.conf /etc/nginx/nginx.conf

# Expose port 8080
EXPOSE 8080