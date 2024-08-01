public class Rating
{
    public int RatingID { get; set; }
    public int UserID { get; set; }
    public int RecipeID { get; set; }
    public int RatingValue { get; set; }
    public DateTime Date { get; set; }
    public User User { get; set; }
    public Recipe Recipe { get; set; }
}