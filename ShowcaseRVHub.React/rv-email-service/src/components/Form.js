import React, {useState, useEffect} from 'react';
import axios from 'axios'
import './form.css'

const Form = () => {
    
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [confirmPass, setConfirmPass] = useState('')
    const [userData, setUserData] = useState([])

    useEffect(() => {
        axios.get('http://localhost:3001/users')
        .then(response => {
            console.log('Users: ', response.data)
            setUserData(response.data)
        })
      }, [email])

    const handleUpdatePasswordSubmit = async (event) => {
        event.preventDefault()

        // Validate password and confrim password
        if (password !== confirmPass) {
            alert('Passwords do not match')
            return
        }
        
        // Filter user to change password
        const filterUser = userData.filter(u => u.email === email)

        // Update password field of user data
        const updateUserPassword = {
            id: filterUser[0].id,
            createdOn: filterUser[0].createdOn,
            firstName: filterUser[0].firstName,
            lastName: filterUser[0].lastName,
            isRemembered: filterUser[0].isRemembered,
            modifiedOn: '',
            phone: filterUser[0].phone,
            password: password,
            username: filterUser[0].username
        }
        console.log('User to change: ', updateUserPassword)
        
        if (filterUser.length > 0) {
            // Set updatedUser variable if exists
            setUserData(updateUserPassword)
                
        } else {
            alert('User not found')
            return
        }        

        try {           

            // Send updated user data to server using PUT method
            const response = await axios.put('http://localhost:3001/update/user', updateUserPassword)
            console.log(response.data)
        } catch (error) {
            alert(error)
            console.error(error)
        }
    }

    return (
        <form className='form' onSubmit={handleUpdatePasswordSubmit}>
        <div>
          <input 
            className='input' 
            type="email" 
            placeholder='Enter Email'
            value={email} 
            onChange={(event) => setEmail(event.target.value)} />
        </div>
        <div>
          <input 
            className='input' 
            type="password" 
            placeholder='Enter Password'
            value={password} 
            onChange={(event) => setPassword(event.target.value)} />
        </div>
        <div>
          <input 
            className='input' 
            type="password" 
            placeholder='Re-enter Password'
            value={confirmPass} 
            onChange={(event) => setConfirmPass(event.target.value)} />
        </div>
        <button className='button' type="submit">Update Password</button>
      </form>
    )
}

export default Form;