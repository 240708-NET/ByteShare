// src/components/RecipeList.tsx
import React from 'react';
import styles from '../styles/MyRecipes.module.css';

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
