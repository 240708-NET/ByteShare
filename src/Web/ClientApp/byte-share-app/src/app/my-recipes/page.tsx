'use client';

import React, { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
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
  const [recipes, setRecipes] = useState<Recipe[]>([]);
  const router = useRouter();

  useEffect(() => {
    const fetchRecipes = async () => {
      try {
        const response = await fetch('/api/recipes'); // Use your API endpoint here
        if (!response.ok) throw new Error('Failed to fetch recipes');
        const data: Recipe[] = await response.json();
        setRecipes(data);
      } catch (error) {
        console.error(error);
      }
    };

    const isLoggedIn = localStorage.getItem('isLoggedIn') === 'true';
    if (!isLoggedIn) {
      router.push('/login');
    } else {
      fetchRecipes();
    }
  }, [router]);

  const handleAddRecipe = async () => {
    const newRecipeTitle = prompt('Enter the title of the new recipe:');
    if (newRecipeTitle) {
      const newRecipeDescription = prompt('Enter the description of the new recipe:');
      const newRecipeInstructions = prompt('Enter the instructions of the new recipe:');
      const newRecipeIngredients = prompt('Enter the ingredients of the new recipe (comma-separated):')?.split(',');
      const newRecipeRating = parseFloat(prompt('Enter the rating of the new recipe (0-5):') || '0');

      const newRecipe = {
        title: newRecipeTitle,
        description: newRecipeDescription || '',
        instructions: newRecipeInstructions || '',
        recipeIngredients: newRecipeIngredients || [],
        ratings: newRecipeRating,
      };

      try {
        const response = await fetch('/api/recipes', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(newRecipe),
        });
        if (!response.ok) throw new Error('Failed to add recipe');
        const addedRecipe: Recipe = await response.json();
        setRecipes([...recipes, addedRecipe]);
      } catch (error) {
        console.error(error);
      }
    }
  };

  const handleEditRecipe = async (recipeId: number) => {
    const recipeToEdit = recipes.find((recipe) => recipe.id === recipeId);
    if (recipeToEdit) {
      const updatedTitle = prompt('Edit the title:', recipeToEdit.title);
      const updatedDescription = prompt('Edit the description:', recipeToEdit.description);
      const updatedInstructions = prompt('Edit the instructions:', recipeToEdit.instructions);
      const updatedIngredients = prompt('Edit the ingredients (comma-separated):', recipeToEdit.recipeIngredients.join(', '))?.split(',');
      const updatedRating = parseFloat(prompt('Edit the rating (0-5):', recipeToEdit.ratings.toString()) || recipeToEdit.ratings.toString());

      const updatedRecipe = {
        ...recipeToEdit,
        title: updatedTitle || recipeToEdit.title,
        description: updatedDescription || recipeToEdit.description,
        instructions: updatedInstructions || recipeToEdit.instructions,
        recipeIngredients: updatedIngredients || recipeToEdit.recipeIngredients,
        ratings: updatedRating,
      };

      try {
        const response = await fetch(`/api/recipes/${recipeId}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(updatedRecipe),
        });
        if (!response.ok) throw new Error('Failed to update recipe');
        const updated = await response.json();
        const updatedRecipes = recipes.map((recipe) =>
          recipe.id === recipeId ? updated : recipe
        );
        setRecipes(updatedRecipes);
      } catch (error) {
        console.error(error);
      }
    }
  };

  const handleDeleteRecipe = async (recipeId: number) => {
    try {
      const response = await fetch(`/api/recipes/${recipeId}`, {
        method: 'DELETE',
      });
      if (!response.ok) throw new Error('Failed to delete recipe');
      const updatedRecipes = recipes.filter((recipe) => recipe.id !== recipeId);
      setRecipes(updatedRecipes);
    } catch (error) {
      console.error(error);
    }
  };

  const handleLogout = () => {
    localStorage.setItem('isLoggedIn', 'false');
    router.push('/login');
  };

  return (
    <div className={styles.container}>
      <h1 className={styles.heading}>My Recipes</h1>
      {recipes.map((recipe) => (
        <div key={recipe.id} className={styles.recipeCard}>
          <h3>{recipe.title}</h3>
          <p>{recipe.description}</p>
          <p>Instructions: {recipe.instructions}</p>
          <p>Ingredients: {recipe.recipeIngredients.join(', ')}</p>
          <p>Rating: {recipe.ratings.toFixed(1)}</p>
          <button className={styles.editButton} onClick={() => handleEditRecipe(recipe.id)}>Edit Recipe</button>
          <button className={styles.deleteButton} onClick={() => handleDeleteRecipe(recipe.id)}>Delete Recipe</button>
        </div>
      ))}
      <button className={styles.addRecipeButton} onClick={handleAddRecipe}>
        Add New Recipe
      </button>
      <button className={styles.logoutButton} onClick={handleLogout}>
        Logout
      </button>
    </div>
  );
};

export default MyRecipes;
