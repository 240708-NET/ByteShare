// src/pages/my-recipes.tsx
'use client';

import React, { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import RecipeList from '../components/RecipeList';
import styles from './my-recipes.module.css';

interface Recipe {
  id: number;
  title: string;
  description: string;
  instructions: string;
  recipeIngredients: string[];
  ratings: number;
}

const MyRecipes: React.FC = () => {
  const [recipes, setRecipes] = useState<Recipe[]>([
    {
      id: 1,
      title: 'Spaghetti Bolognese',
      description: 'A classic Italian pasta dish with rich meat sauce.',
      instructions: '1. Cook pasta. 2. Prepare sauce. 3. Combine and serve.',
      recipeIngredients: ['Pasta', 'Ground Beef', 'Tomato Sauce', 'Onion', 'Garlic'],
      ratings: 4.5,
    },
    {
      id: 2,
      title: 'Chicken Curry',
      description: 'A spicy and flavorful chicken curry.',
      instructions: '1. Cook chicken. 2. Prepare curry sauce. 3. Combine and serve.',
      recipeIngredients: ['Chicken', 'Curry Powder', 'Coconut Milk', 'Onion', 'Garlic'],
      ratings: 4.8,
    },
    {
      id: 3,
      title: 'Beef Stroganoff',
      description: 'A rich and creamy beef stroganoff.',
      instructions: '1. Cook beef. 2. Prepare sauce. 3. Combine and serve over noodles.',
      recipeIngredients: ['Beef', 'Mushrooms', 'Sour Cream', 'Onion', 'Garlic'],
      ratings: 4.7,
    },
  ]);

  const router = useRouter();

  useEffect(() => {
    const isLoggedIn = localStorage.getItem('isLoggedIn') === 'true'; 
    if (!isLoggedIn) {
      router.push('/login'); 
    }
  }, [router]);

  const handleAddRecipe = () => {
    const newRecipeTitle = prompt('Enter the title of the new recipe:');
    if (newRecipeTitle) {
      const newRecipeDescription = prompt('Enter the description of the new recipe:');
      const newRecipeInstructions = prompt('Enter the instructions of the new recipe:');
      const newRecipeIngredients = prompt('Enter the ingredients of the new recipe (comma-separated):')?.split(',');
      const newRecipeRating = parseFloat(prompt('Enter the rating of the new recipe (0-5):') || '0');

      const newRecipe: Recipe = {
        id: recipes.length + 1,
        title: newRecipeTitle,
        description: newRecipeDescription || '',
        instructions: newRecipeInstructions || '',
        recipeIngredients: newRecipeIngredients || [],
        ratings: newRecipeRating,
      };
      setRecipes([...recipes, newRecipe]);
    }
  };

  const handleLogout = () => {
    localStorage.setItem('isLoggedIn', 'false'); 
    router.push('/login'); 
  };

  return (
    <div className={styles.container}>
      <h1 className={styles.heading}>My Recipes</h1>
      <RecipeList recipes={recipes} />
      <button className={styles.addRecipeButton} onClick={handleAddRecipe}>
        Add New Recipe
      </button>
      <button className="logoutButton" onClick={handleLogout}>
        Logout
      </button>
    </div>
  );
};

export default MyRecipes;
