'use strict';

/** @type {import('sequelize-cli').Migration} */
module.exports = {
  async up (queryInterface, Sequelize) {
    await queryInterface.bulkInsert('Genre', [   
      {id: 1, title: 'Комедия'},
      {id: 2, title: 'Ужасы'},
      {id: 3, title: 'Триллер'}
    ])
  },

  async down (queryInterface, Sequelize) {
    await queryInterface.bulkDelete(
      'Genre', 
      null /* тут можно прописать условие WHERE */
    )
  }
};
