/*
This React component renders the header of the application, including a navigation bar with a logo and menu links. 
The logo links to the homepage, and there is a button for login or registration. Navigation styles are applied 
using an external CSS module.
*/


import React from 'react';
import Link from 'next/link';
import NavLinks from './NavLink'
import styles from '../styles/HeaderStyle.module.css'

const Header: React.FC = () => {
    return (
        <header>
            <nav className={styles.navigation}>
                <div className={styles.logoContainer}>
                    <Link href="/" className={styles.logo}>
                        <img src="/images/BowlLogo.png" alt="ByteShare Logo" />
                        Byte<span>Share</span>
                    </Link>
                </div>

                <ul className={styles.menuContainer}>
                    <NavLinks />
                    <li><Link href="/login"><button>Login | Register</button></Link></li>
                </ul>
            </nav>
        </header>
    );
};

export default Header;
