FROM mysql:8.0.37
COPY dump.sql /docker-entrypoint-initdb.d/
ENV TZ="Europe/Moscow"
ENV MYSQL_ROOT_HOST="%" 
