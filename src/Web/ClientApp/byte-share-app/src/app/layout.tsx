import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./styles/globals.css";

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
      <body className={inter.className}>{children}</body>
    </html>
  );
}
