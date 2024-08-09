    'use client';
    import React, { useState, FormEvent } from 'react';
    import { useRouter } from 'next/navigation';

    const FormField: React.FC<{ id: string, label: string, type: string, value: string, onChange: (e: React.ChangeEvent<HTMLInputElement>) => void }> = ({ id, label, type, value, onChange }) => (
    <div className="form-group">
        <label htmlFor={id}>{label}</label>
        <input
        type={type}
        id={id}
        name={id}
        required
        value={value}
        onChange={onChange}
        className="input-field"
        />
    </div>
    );

    const Login: React.FC = () => {
    const [username, setUsername] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const router = useRouter();

    const handleFormSubmit = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        console.log('Username:', username);
        console.log('Password:', password);
        localStorage.setItem('isLoggedIn', 'true');
        router.push('/my-recipes');
    };

    return (
        <div className="login-container">
        <h2>Login</h2>
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
            <button type="submit" className="submit-button">Login</button>
        </form>
        </div>
    );
    };

    export default Login;
