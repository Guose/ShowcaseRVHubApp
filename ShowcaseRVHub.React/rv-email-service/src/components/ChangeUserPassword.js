import React from 'react'

const ChangeUserPassword = ({updateFormData, handleUpdatePassword}) => {
    return (
        <>
            <input 
                type="email"
                name='email'
                value={updateFormData.email}
                required='required'
                placeholder='Enter Email'
                onChange={handleUpdatePassword}
                />

            <input
                type='password'
                name='password'
                value={updateFormData.password}
                required='required'
                placeholder='Enter Password' 
                onChange={handleUpdatePassword}
                />

            <input
                type='password'
                name='confirmPass' 
                value={updateFormData.confirmPass}
                required='required'
                placeholder='Re-enter Password'
                onChange={handleUpdatePassword}
                />
            <button type="submit"> Submit </button>
        </>
    )
}

export default ChangeUserPassword