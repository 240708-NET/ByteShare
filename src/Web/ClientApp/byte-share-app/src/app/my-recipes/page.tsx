// src/pages/recipes.tsx
'use client';

import React, { useState, useEffect } from 'react';
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


//   const [recipes, setRecipes] = useState<Recipe[]>([]);
//   const [loading, setLoading] = useState<boolean>(true);
//   const [error, setError] = useState<string | null>(null);

//   useEffect(() => {
//     const fetchRecipes = async () => {
//       try {
//         const response = await fetch('http://localhost:5101/api/recipes'); //need an end point for just a single user's recipes
//         if (!response.ok) {
//           throw new Error('Failed to fetch recipes');
//         }
//         const data = await response.json();
//         setRecipes(data);
//       } catch (err) {
//         if (err instanceof Error) {
//           setError(err.message);
//         } else {
//           setError('An unknown error occurred');
//         }
//       } finally {
//         setLoading(false);
//       }
//     };

//     fetchRecipes();
//   }, []);

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

  return (
    <>
      <div className={styles.container}>
        <h1 className={styles.heading}>My Recipes</h1>
        {/* {loading ? (
          <div>Loading...</div>
        ) : error ? (
          <div>Error: {error}</div>
        ) : ( */}
          <>
            <RecipeList recipes={recipes} />
          </>
        {/* )} */}
        <button className={styles.addRecipeButton} onClick={handleAddRecipe}>
          Add New Recipe
        </button>
      </div>
    </>
  );
};

export default MyRecipes;
