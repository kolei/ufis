# создаем образ на основе Node.js версии 20 на основе минималистичного linux-образа alpine
FROM node:20-alpine

# устанавливаем рабочую директорию
WORKDIR /app

# копируем package.json и package-lock.json
COPY package*.json ./

# устанавливаем зависимости (как раз тут будет заполнен каталог node_modules)
RUN npm install

# копируем остальные файлы проекта
COPY . .

# открываем порт 3000
EXPOSE 3000

# запускаем сервер Express.js
# CMD ["node", "index.js"]

# даем права на выполнение скрипту
RUN chmod 777 ./entrypoint.sh
# точка входа 
ENTRYPOINT [ "./entrypoint.sh" ]
