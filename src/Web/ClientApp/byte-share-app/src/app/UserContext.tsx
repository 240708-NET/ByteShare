import React, { useState, useContext, createContext, ReactNode } from 'react';

// Define the shape of the context value
interface UserContextType {
  username: string;
  setUsername: (username: string) => void;
}

// Provide a default value that matches the context shape
const defaultContextValue: UserContextType = {
  username: "User",
  setUsername: () => {}
};

const UserContext = createContext<UserContextType>(defaultContextValue);

export const UserProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [username, setUsername] = useState("User");

  return (
    <UserContext.Provider value={{ username, setUsername }}>
      {children}
    </UserContext.Provider>
  );
}

// To use this context, import UserContext and use useContext(UserContext) in your components.
