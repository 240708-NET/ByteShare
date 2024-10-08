/*
This React component renders the homepage of ByteShare. It displays a welcoming message encouraging users to join and engage with the platform. 
The message emphasizes discovering new dishes and sharing culinary creations. 
Styling is applied using an external CSS module.
*/


'use client';

import React from 'react';
import styles from './home.module.css';

const HomePage: React.FC = () => {
    return (
        <main>
            <div className = {styles.welcomeContainer}>
                <p>Join ByteShare today and turn your passion for cooking into a shared experience. Whether you're looking to discover new dishes or share your culinary creations, ByteShare is the perfect place to connect through the joy of food. Bon appétit!</p>
            </div>
      </main>
    )
};

export default HomePage;