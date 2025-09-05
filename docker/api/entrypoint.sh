#!/bin/sh
# накатываем начальные данные
npx sequelize-cli db:seed:all

# запускаем сервер
exec node index.js
