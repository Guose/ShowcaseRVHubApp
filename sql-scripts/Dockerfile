FROM mcr.microsoft.com/mssql/server:latest
ENV SA_PASSWORD=5p3ctrum!
ENV ACCEPT_EULA=Y
USER root
RUN mkdir -p /docker-entrypoint-initdb.d
ADD *.sql /docker-entrypoint-initdb.d
