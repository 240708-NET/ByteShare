/**
 * RootLayout component serves as the main layout for the application.
 * It wraps all pages with a common structure including the Header and Footer components.
 * It also applies global styles and font settings to ensure consistent typography and design across the site.
 */

import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./styles/globals.css";

import Header from "./components/Header";
import Footer from "./components/Footer";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: "ByteShare | Where Recipes Live",
  description: "Join ByteShare, a vibrant community where food enthusiasts can explore, share, and enjoy recipes from around the world. Discover new dishes, share your culinary creations, and connect with fellow cooks. Your go-to platform for cooking inspiration and recipe sharing.",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (

    <html lang="en">
      <body className={inter.className}>
        <Header />
        {children}
        <Footer />
      </body>
    </html>
  );
}
