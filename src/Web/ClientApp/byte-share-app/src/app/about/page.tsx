'use client';

import React from 'react';
import styles from './about-style.module.css';

const AboutUsPage: React.FC = () => {
    return (
        <main>
        <div className={styles.aboutUsContainer}>
            <div className={styles.header}>
                <h1>Byte<span>Share</span> DevTeam</h1>
                <p>Meet the team behind our project</p>
            </div>
    
            <div className={styles.developers}>
                <div className={styles.developer}>
                    <img src="../images/BowlLogo.png" alt="Developer 1"/>
                    <h3>Bilal Mirza</h3>
                    <p>Front-End Developer and Scrum Master</p>
                </div>
                <div className={styles.developer}>
                    <img src="../images/BowlLogo.png" alt="Developer 2"/>
                    <h3>Bremer Jonathan</h3>
                    <p>Server-Side Integration Lead</p>
                </div>
                <div className={styles.developer}>
                    <img src="../images/BowlLogo.png" alt="Developer 3"/>
                    <h3>Tamekia Nelson</h3>
                    <p>QA and Testing Specialist</p>
                </div>
                <div className={styles.developer}>
                    <img src="../images/BowlLogo.png" alt="Developer 4"/>
                    <h3>Robert Tan Huynh</h3>
                    <p>Backend Solutions Architect</p>
                </div>
            </div>
        </div>
    </main>
    )
};

export default AboutUsPage;
