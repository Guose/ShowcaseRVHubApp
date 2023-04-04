const express = require('express')
const bodyParser = require('body-parser')
const cors = require('cors')
const axios = require('axios')
const app = express()

app.use(cors({origin: 'http://192.168.1.10:3000'}))
app.use((req, res, next) => {
    res.setHeader('Access--Control-Allow-Origin', 'http://192.168.1.10:3000')
    next()
})
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
    if(req.body === null || req.body === undefined) {
        console.error("Request body is null")
        return
    }
    try {
        
    fetch(url + '/users/' + req.body.id , {
        method: 'PUT',
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify(req.body)
    })
    .then(console.log('Update to id: ', req.body.id))
    .catch((err) => {console.log(err.message)})

    res.send("Send was successfull")
    } catch (error) {
        console.error(error)
    }
    
})

app.listen(PORT, () => {
    console.log('Server is running on PORT: ', PORT)
    console.log('React server url: http://localhost:3001/update/user')
    console.log('Webservice api url is: ', url + '/users/{id}')
})