/*
This React component renders the login and registration page by including the `Login` component. 
It wraps the `Login` component in a `div` container, providing the structure for the page.
*/


'use client';

import React from 'react';
import Login from '../components/Login';

const LoginRegisterPage: React.FC = () => {
    return (
        <div>
            <Login />
        </div>
    );
};

export default LoginRegisterPage;
