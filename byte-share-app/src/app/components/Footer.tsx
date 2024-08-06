import React from 'react';
import Link from 'next/link';

const Footer: React.FC = () => {
    return (
        <header>
            <nav className="navigation">
                <div className="logo-container">
                    <Link href="/">
                        <div className="logo">
                            <img src="/images/BowlLogo.png" alt="ByteShare Logo" />
                            Byte<span>Share</span>
                        </div>
                    </Link>
                </div>
                <ul className="menu-container">
                    <li><Link href="/">Home</Link></li>
                    <li><Link href="/recipes">Recipes</Link></li>
                    <li><Link href="/about">About Us</Link></li>
                    <li><Link href="/my-recipes">My Recipes</Link></li>
                    <li><Link href="/login-register"><button>Login | Register</button></Link></li>
                </ul>
            </nav>
        </header>
    );
};

export default Footer;