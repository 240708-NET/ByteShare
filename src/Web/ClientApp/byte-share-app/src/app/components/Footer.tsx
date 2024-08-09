/*
This React component renders the footer of the application. It displays the current year and a copyright notice 
for ByteShare, as well as a credit to Team 3. The footer is styled using an external CSS module.
*/

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
