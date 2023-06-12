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
    axios(url + '/users')
    .then(response => {
        res.json(response.data)
    })
    // fetch(url + '/users')
    // .then(response => response.json())
    // .then(data => {
    //     console.log(data)
    //     res.json(data)
    // })
})

app.patch('/update/password', (req, res) => {
    if(req.body === null || req.body === undefined) {
        console.error("Request body is null")
        return
    }
    try {
        axios.patch(url + '/users/' + req.body.id, [{
            op: 'replace',
            path: '/Password',
            value: req.body.password
        }], {
            headers: {"Content-Type": "application/json"}
        })
        .then(response => {
            console.log(req.body.password)
            console.log('Password updated successfully')
            res.json({message: 'Password updated successfully'})
        })
        .catch(error => {
            console.error('.then catch error: ', error)
            res.status(500).json({error: 'An error occurred - .then/catch'})
        })
    } catch (error) {
        console.error('try/catch error: ', error)
        res.status(500).json({errror: 'An error occurred - try/catch'})
    }
})

app.put('/update/user', (req, res) => {
    if(req.body === null || req.body === undefined) {
        console.error("Request body is null")
        return
    }
    try {        
    axios.put(url + '/users/' + req.body.id, {
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