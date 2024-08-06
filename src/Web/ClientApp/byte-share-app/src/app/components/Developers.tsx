import React from 'react';
import Link from 'next/link';
import styles from '../styles/HeaderStyle.module.css'

const Developers: React.FC = () => {
    return (
        <div className="developers">
            <div className="developer">
                <img src="../images/BowlLogo.png" alt="Developer 1"/>
                <h3>Bilal Mirza</h3>
                <p>Title</p>
            </div>
            <div className="developer">
                <img src="../images/BowlLogo.png" alt="Developer 2"/>
                <h3>Bremer Jonathan</h3>
                <p>Title</p>
            </div>
            <div className="developer">
                <img src="../images/BowlLogo.png" alt="Developer 3"/>
                <h3>Tamekia Nelson</h3>
                <p>Title</p>
            </div>
            <div className="developer">
                <img src="../images/BowlLogo.png" alt="Developer 4"/>
                <h3>Robert Tan Huynh</h3>
                <p>Title</p>
            </div>
        </div>
    );
};

export default Developers;