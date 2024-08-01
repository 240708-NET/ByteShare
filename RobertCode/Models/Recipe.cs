public class Recipe
{
    public int RecipeID { get; set; }
    public int UserID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Instructions { get; set; }
    public DateTime Date { get; set; }
    public User User { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
    public ICollection<Rating> Ratings { get; set; }
}