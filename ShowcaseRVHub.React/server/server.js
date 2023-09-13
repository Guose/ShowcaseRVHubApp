const express = require('express')
const bodyParser = require('body-parser')
const cors = require('cors')
const axios = require('axios')
const app = express()

app.use(cors())
app.use(bodyParser.json())

const baseAddress = process.env.REACT_APP_API_BASE_URL || 'http://webapi:5012'
const url = baseAddress + '/api'
const PORT = process.env.PORT || 3001

app.get('/users', (req, res) => {
    axios(url + '/users')
    .then(response => {
        res.json(response.data)
    })
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
        .then((response) => {
            if (response.status >= 200 && response.status < 300) {
                // Successfull status code
                console.log(req.body.password)
                console.log('Password updated successfully')
                res.json({message: 'Password updated successfully'})
            } else {
                // Handle other status codes
                console.log('Received an unexpected status code:', response.status)
                res.status(response.status).send('Received an unexpected status code')
            }
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
    axios.put(url + '/users/' + req.body.id, req.body, {
        headers: { "Content-Type": "application/json"}
    })
    .then(() => {
        console.log('Update to id: ', req.body.id)
        res.send("Send was successfull")
    })
    .catch((err) => {
        console.log(err.message)
        res.status(500).send('An error has occurred in the \'PUT\'/.then/catch')
    })
    } catch (error) {
        console.error(error)
        res.status(500).send('An error has occurred in the try/catch')
    }
    
})

app.listen(PORT, () => {
    console.log('Server is running on PORT: ', PORT)
    console.log('React server url: http://localhost:3001/update/user')
    console.log('Webservice api url is: ', url + '/users/{id}')
})