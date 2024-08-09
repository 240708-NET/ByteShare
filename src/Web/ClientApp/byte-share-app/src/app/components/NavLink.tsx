/*
This React component renders a navigation menu with links to different pages. 
It uses `usePathname` to determine the current route and applies an 'active' class to the currently active link. 
Each menu item includes an icon and label, with icons imported from Heroicons. 
The navigation links are styled using an external CSS module.
*/


'use client';

import React from 'react';
import Link from 'next/link';
import { usePathname } from 'next/navigation'; // Import usePathname to get the current route
import { HomeIcon, GlobeAltIcon, HeartIcon, BookOpenIcon, UserIcon } from '@heroicons/react/24/outline';
import styles from '../styles/HeaderStyle.module.css'

const links = [
  { name: 'Home', href: '/', icon: HomeIcon },
  { name: 'Recipes', href: '/all-recipes', icon: GlobeAltIcon },
  { name: 'About Us', href: '/about', icon: HeartIcon },
  { name: 'My Recipes', href: '/my-recipes', icon: BookOpenIcon },
];

export default function NavLinks() {
  const pathname = usePathname(); // Get the current pathname

  return (
    <ul className={styles.menuContainer}>
      {links.map((link) => {
        const LinkIcon = link.icon;
        const isActive = pathname === link.href; // Check if the link is active

        return (
          <li key={link.name}>
            <Link href={link.href} className={isActive ? 'active' : ''}>
              <LinkIcon className={styles.icon} />
              {link.name}
            </Link>
          </li>
        );
      })}
    </ul>
  );
}
