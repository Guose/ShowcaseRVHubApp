const express = require('express')
const bodyParser = require('body-parser')
const cors = require('cors')
const axios = require('axios')
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
    if(req.body === null) {
        console.error("Request body is null")
        return
    }
    try {
        console.log('Update to: ', req.body.id)
    fetch(url + '/user/' + req.body.id , {
        method: 'PUT',
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify(req.body)
    })
    .then(console.log(req.body))
    .catch((err) => {console.log(err.message)})

    res.send("Send was successfull")
    } catch (error) {
        console.error(error)
    }
    
})

app.listen(PORT, () => {
    console.log('Server is running on PORT: ', PORT)
    console.log('User api url is: ', url + '/user/{id}')
})