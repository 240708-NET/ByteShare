// src/components/Footer.tsx
import React from 'react';
import styles from '../styles/FooterStyle.module.css';

const Footer: React.FC = () => {
    return (
        <footer className={styles.footer}>
            <p>&copy; {new Date().getFullYear()} ByteShare. All rights reserved.</p>
            <p>Brought to you by <strong>Team 3</strong></p>
        </footer>
    );
};

export default Footer;
