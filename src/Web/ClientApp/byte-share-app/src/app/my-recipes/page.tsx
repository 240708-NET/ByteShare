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

  const handleEditRecipe = (recipeId: number) => {
    const recipeToEdit = recipes.find((recipe) => recipe.id === recipeId);
    if (recipeToEdit) {
      const updatedTitle = prompt('Edit the title:', recipeToEdit.title);
      const updatedDescription = prompt('Edit the description:', recipeToEdit.description);
      const updatedInstructions = prompt('Edit the instructions:', recipeToEdit.instructions);
      const updatedIngredients = prompt('Edit the ingredients (comma-separated):', recipeToEdit.recipeIngredients.join(', '))?.split(',');
      const updatedRating = parseFloat(prompt('Edit the rating (0-5):', recipeToEdit.ratings.toString()) || recipeToEdit.ratings.toString());

      const updatedRecipe: Recipe = {
        ...recipeToEdit,
        title: updatedTitle || recipeToEdit.title,
        description: updatedDescription || recipeToEdit.description,
        instructions: updatedInstructions || recipeToEdit.instructions,
        recipeIngredients: updatedIngredients || recipeToEdit.recipeIngredients,
        ratings: updatedRating,
      };

      const updatedRecipes = recipes.map((recipe) =>
        recipe.id === recipeId ? updatedRecipe : recipe
      );
      setRecipes(updatedRecipes);
    }
  };

  const handleDeleteRecipe = (recipeId: number) => {
    const updatedRecipes = recipes.filter((recipe) => recipe.id !== recipeId);
    setRecipes(updatedRecipes);
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
          <button className= "editButton" onClick={() => handleEditRecipe(recipe.id)}>Edit Recipe</button>
          <button className= "deleteButton" onClick={() => handleDeleteRecipe(recipe.id)}>Delete Recipe</button>
        </div>
      ))}
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
