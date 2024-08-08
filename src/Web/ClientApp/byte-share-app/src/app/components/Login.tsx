// "use client"; // Add this line at the top

// import React, { useState, FormEvent } from 'react';
// // import './Login.css'; // Ensure you have the corresponding CSS file

// const Login: React.FC = () => {
//   const [username, setUsername] = useState<string>('');
//   const [password, setPassword] = useState<string>('');

//   const handleFormSubmit = (e: FormEvent<HTMLFormElement>) => {
//     e.preventDefault();
//     // Handle login logic here, e.g., API call
//     console.log('Username:', username);
//     console.log('Password:', password);
//   };

//   return (
//     <div className="login-container">
//       <h2>Login</h2>
//       <form onSubmit={handleFormSubmit}>
//         <div className="form-group">
//           <label htmlFor="username">Username</label>
//           <input
//             type="text"
//             id="username"
//             name="username"
//             required
//             value={username}
//             onChange={(e) => setUsername(e.target.value)}
//           />
//         </div>
//         <div className="form-group">
//           <label htmlFor="password">Password</label>
//           <input
//             type="password"
//             id="password"
//             name="password"
//             required
//             value={password}
//             onChange={(e) => setPassword(e.target.value)}
//           />
//         </div>
//         <button type="submit">Login</button>
//       </form>
//     </div>
//   );
// };

// export default Login;
