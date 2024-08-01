public class Ingredient
{
    public int IngredientID { get; set; }
    public int RecipeID { get; set; }
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public Recipe Recipe { get; set; }
}