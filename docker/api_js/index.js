const express = require('express')
const { sequelize } = require('./models')
const { QueryTypes } = require('sequelize')

const app = express()
const port = 3000

console.log('NODE_ENV:', process.env.NODE_ENV)

app.get('/genres', async (req, res) => {
    try {
    res.json(await sequelize.query(`
      SELECT *
      FROM Genre
    `, {
      logging: false,
      type: QueryTypes.SELECT
    }))
  } catch (error) {
    console.error(error)
  } finally {
    res.end()
  }
})

app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
})
