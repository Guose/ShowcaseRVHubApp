import React, {useState, useEffect} from 'react'
import { ToastContainer, toast} from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'
import axios from 'axios'
import './css/form.css'

function Form() {
    let isSuccess = false
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [confirmPass, setConfirmPass] = useState('')
    const [userData, setUserData] = useState([])

    useEffect(() => {
        try {
            axios.get('http://localhost:3001/users')
            .then(response => {
                console.log('Users: ', response.data)
                setUserData(response.data)
            })
        } catch (error) {
            console.error('There is an error in the useEffect function: ', error)
        }
        
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
            password: password
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
            const response = await axios.patch('http://localhost:3001/update/password', updateUserPassword)
            if (response.status >= 200 && response.status < 300) {
                console.log(response.data)
                isSuccess = true
                setEmail('')
                setPassword('')
                setConfirmPass('') 
            } else {
                console.error('Received an unexpected status code:', response.status)
                isSuccess = false
            }
            
        } catch (error) {
            alert(error)
            console.error(error)
            isSuccess = false;
        } finally {                       
            checkSuccessRun(isSuccess)            
        }
    }
    const checkSuccessRun = async (success) => {
        if (success) {
            toast.success('Password has been changed, succesfully!', {
                onClose: () => {
                    setTimeout(() => {
                        window.location.href = '/success'
                    }, 5000)
                }
            })
         } else {
            toast.error('Something went wrong! Try again or contact tech support at support@showcasemi.com')
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
        <ToastContainer />
      </form>
    )
}

export default Form;