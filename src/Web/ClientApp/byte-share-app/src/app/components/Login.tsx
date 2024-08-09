'use client';
import React, { useState, useEffect, FormEvent } from 'react';
import { useRouter } from 'next/navigation';
import styles from '../login/LoginForm.module.css';

const FormField: React.FC<{ id: string, label: string, type: string, value: string, onChange: (e: React.ChangeEvent<HTMLInputElement>) => void }> = ({ id, label, type, value, onChange }) => (
    <div className={styles.formGroup}>
        <label htmlFor={id}>{label}</label>
        <input
            type={type}
            id={id}
            name={id}
            required
            value={value}
            onChange={onChange}
            className={styles.inputField}
        />
    </div>
);

const Login: React.FC = () => {
    const [username, setUsername] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const [errorMessage, setErrorMessage] = useState<string | null>(null);
    const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false); //added 8/8
    const router = useRouter();

    useEffect(() => {
        const checkLoginStatus = () => {
            const loggedInStatus = localStorage.getItem('isLoggedIn') === 'true';
            setIsLoggedIn(loggedInStatus);
        };

        checkLoginStatus();
    }, []); //added 8/8

    const handleFormSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const target = e.nativeEvent as SubmitEvent;
        const action = (target.submitter as HTMLButtonElement)?.value;

        // Create the payload for the API request
        const payload = {
            username: username,
            password: password,
            Email: "ada@revature.com"
        };

        if (action === 'login') {
            try {
                // Send GET request to the API endpoint
                const response = await fetch(`http://localhost:5101/api/users/username=${username}&password=${password}`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });

                // Check if the response is ok
                if (response.ok) {
                    const data = await response.json();
                    if (data && data.length > 0) {
                        // Successful login
                        localStorage.setItem('isLoggedIn', 'true');
                        router.push('/my-recipes');
                    } else {
                        // No matching user found
                        setErrorMessage('Invalid username or password');
                    }
                } else {
                    // Response not OK
                    setErrorMessage('Login failed');
                }
            } catch (error) {
                console.error('Error:', error);
                setErrorMessage('Error occurred during login');
            }
        } else if (action === 'register') {
            try {
                // Send POST request to the API endpoint
                const response = await fetch('http://localhost:5101/api/users', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(payload),
                });

                // Check if the response is ok
                if (response.ok) {
                    localStorage.setItem('isLoggedIn', 'true');
                    router.push('/my-recipes');
                } else {
                    setErrorMessage('Registration failed');
                }
            } catch (error) {
                console.error('Error:', error);
                setErrorMessage('Error occurred during registration');
            }
        }
    };

    return (
        <div className={styles.loginContainer}>
            <h2>Login</h2>
            {errorMessage && <p className={styles.errorMessage}>{errorMessage}</p>}
            <form onSubmit={handleFormSubmit}>
                <FormField
                    id="username"
                    label="Username"
                    type="text"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                />
                <FormField
                    id="password"
                    label="Password"
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <div className={styles.buttonContainer}> 
                    {!isLoggedIn && (
                        <>
                            <button type="submit" name="action" value="login" className={styles.submitButton}>Login</button>
                            <button type="submit" name="action" value="register" className={styles.submitButton}>Register</button>
                        </>
                    )}
                </div> 
            </form> 
        </div>
    );
};

export default Login;
