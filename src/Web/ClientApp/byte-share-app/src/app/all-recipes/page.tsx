/*
This React component displays a list of recipes fetched from an API. It handles loading and error states, 
and allows users to rate recipes using star buttons. The component organizes the recipes into cards with details 
such as title, description, author, and instructions, and includes styling for a clean and responsive layout.
*/


'use client';

import React, { useState, useEffect } from 'react';
import Header from '../components/Header';
import styles from './all-recipes.module.css';

// Updated Recipe interface based on new JSON structure
interface Recipe {
  id: number;
  title: string;
  description: string;
  instructions: string;
  recipeIngredients: {
    RecipeId: number;
    Name: string;
    Amount: number;
    Unit: string;
    CreatorId: number;
    LastModifierId: number;
  }[];
  ratings: number;
  author: string;
}

const AllRecipes: React.FC = () => {
  const [recipes, setRecipes] = useState<Recipe[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    // Fetch recipes from the ASP.NET Core API
    const fetchRecipes = async () => {
      try {
        const response = await fetch('http://localhost:5101/api/recipes'); // Adjust the URL if necessary
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data: Recipe[] = await response.json();
        setRecipes(data);
      } catch (error) {
        setError('Failed to fetch recipes');
        console.error('Error fetching recipes:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchRecipes();
  }, []);

  const handleRateRecipe = (id: number, rating: number) => {
    // Dummy function to handle rating
    const updatedRecipes = recipes.map(recipe =>
      recipe.id === id ? { ...recipe, ratings: rating } : recipe
    );
    setRecipes(updatedRecipes);
  };

  if (loading) return <p>Loading...</p>;
  if (error) return <p>{error}</p>;

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
              {/* <ul className={styles.recipeIngredients}>
                {recipe.recipeIngredients.map((ingredient, index) => (
                  <li key={index}>
                    {ingredient.Amount} {ingredient.Unit} of {ingredient.Name}
                  </li>
                ))}
              </ul> */}
            </div>
          ))}
        </div>
      </div>
    </>
  );
};

export default AllRecipes;
