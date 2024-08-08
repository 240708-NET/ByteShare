// src/pages/AllRecipes.tsx
'use client';

import React, { useState } from 'react';
import Header from '../components/Header';
import styles from '../styles/AllRecipes.module.css';

interface Recipe {
  id: number;
  title: string;
  description: string;
  instructions: string;
  recipeIngredients: string[];
  ratings: number;
  author: string;
}

const initialRecipes: Recipe[] = [
  {
    id: 1,
    title: 'Spaghetti Bolognese',
    description: 'A classic Italian pasta dish with rich, meaty sauce.',
    instructions: '1. Cook the pasta. 2. Prepare the sauce. 3. Combine and serve.',
    recipeIngredients: ['Spaghetti', 'Ground Beef', 'Tomato Sauce', 'Onion', 'Garlic', 'Carrot', 'Celery'],
    ratings: 4,
    author: 'John Doe'
  },
  {
    id: 2,
    title: 'Chicken Curry',
    description: 'A flavorful and spicy chicken curry.',
    instructions: '1. Marinate the chicken. 2. Cook the curry base. 3. Add chicken and simmer.',
    recipeIngredients: ['Chicken', 'Onion', 'Garlic', 'Ginger', 'Tomato', 'Spices', 'Coconut Milk'],
    ratings: 5,
    author: 'Jane Smith'
  },
  {
    id: 3,
    title: 'Vegetable Stir Fry',
    description: 'A quick and healthy vegetable stir fry.',
    instructions: '1. Chop the vegetables. 2. Stir fry with sauce. 3. Serve with rice or noodles.',
    recipeIngredients: ['Bell Pepper', 'Broccoli', 'Carrot', 'Soy Sauce', 'Garlic', 'Ginger'],
    ratings: 3,
    author: 'Alice Johnson'
  }
];

const AllRecipes: React.FC = () => {
  const [recipes, setRecipes] = useState<Recipe[]>(initialRecipes);

  const handleRateRecipe = (id: number, rating: number) => {
    // Dummy function to handle rating
    const updatedRecipes = recipes.map(recipe =>
      recipe.id === id ? { ...recipe, ratings: rating } : recipe
    );
    setRecipes(updatedRecipes);
  };

  return (
    <>
      <Header />
      <div className={styles.container}>
        <h1 className={styles.heading}>All Recipes</h1>
        <div className={styles.recipeList}>
          {recipes.map(recipe => (
            <div key={recipe.id} className={styles.recipeCard}>
              <h2 className={styles.recipeTitle}>{recipe.title}</h2>
              <p className={styles.recipeDescription}>{recipe.description}</p>
              <p className={styles.recipeAuthor}>By: {recipe.author}</p>
              <div className={styles.recipeRating}>
                <span>Rating: </span>
                {[...Array(5)].map((_, i) => (
                  <button
                    key={i}
                    className={i < recipe.ratings ? styles.activeStar : styles.inactiveStar}
                    onClick={() => handleRateRecipe(recipe.id, i + 1)}
                  >
                    ★
                  </button>
                ))}
              </div>
              <p className={styles.recipeInstructions}>{recipe.instructions}</p>
              <ul className={styles.recipeIngredients}>
                {recipe.recipeIngredients.map((ingredient, index) => (
                  <li key={index}>{ingredient}</li>
                ))}
              </ul>
            </div>
          ))}
        </div>
      </div>
    </>
  );
};

export default AllRecipes;
