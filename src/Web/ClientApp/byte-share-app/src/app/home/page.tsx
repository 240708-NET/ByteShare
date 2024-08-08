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