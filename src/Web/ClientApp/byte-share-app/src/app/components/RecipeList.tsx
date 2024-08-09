/*
This React component displays a list of recipes, each including a title, description, instructions, ingredients, and rating. 
It takes a list of recipes as a prop and maps over them to render each recipe in a styled list. 
The component uses styles from an external CSS module for layout and design.
*/

import React from 'react';
import styles from '../my-recipes/my-recipes.module.css';

interface Recipe {
  id: number;
  title: string;
  description: string;
  instructions: string;
  recipeIngredients: string[];
  ratings: number;
}

interface RecipeListProps {
  recipes: Recipe[];
}

const RecipeList: React.FC<RecipeListProps> = ({ recipes }) => {
  return (
    <ul className={styles.recipeList}>
      {recipes.map((recipe) => (
        <li key={recipe.id} className={styles.recipeItem}>
          <h2>{recipe.title}</h2>
          <p><strong>Description:</strong> {recipe.description}</p>
          <p><strong>Instructions:</strong> {recipe.instructions}</p>
          <p><strong>Ingredients:</strong> {recipe.recipeIngredients.join(', ')}</p>
          <p><strong>Rating:</strong> {recipe.ratings} / 5</p>
        </li>
      ))}
    </ul>
  );
};

export default RecipeList;
