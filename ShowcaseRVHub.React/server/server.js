const express = require('express')
const bodyParser = require('body-parser')
const cors = require('cors')
const app = express()

app.use(cors())
app.use(bodyParser.json())

const baseAddress = 'http://localhost:5012'
const url = baseAddress + '/api'
const PORT = process.env.PORT || 3001

app.get('/users', (req, res) => {
    fetch(url + '/users')
    .then(response => response.json())
    .then(data => {
        console.log(data)
        res.json(data)
    })
})

app.put('/update/user', (req, res) => {
    console.log('Update to: ', req.body.id)
    fetch(url + '/users/{' + req.body.id + '}', {
        method: 'PUT',
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify(req.body)
    })
})

app.listen(PORT, () => {
    console.log('Server is running on PORT: ', PORT)
    console.log('User api is fetching from is: ', url + '/users')
})