using System.Text.Json.Serialization;
using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class User : BaseAuditableEntity<int, User>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    [JsonIgnore]
    public ICollection<Recipe> Recipes { get; } = [];
    [JsonIgnore]
    public ICollection<Ingredient> Ingredients { get; } = [];
    [JsonIgnore]
    public ICollection<RecipeIngredient> RecipeIngredients { get; } = [];
    [JsonIgnore]
    public ICollection<RecipeRating> RecipeRatings { get; } = [];
    [JsonIgnore]
    public ICollection<User> UsersCreated { get; } = [];
    [JsonIgnore]
    public ICollection<User> UsersModified { get; } = [];
    [JsonIgnore]
    public ICollection<User> Followers { get; } = [];
    [JsonIgnore]
    public ICollection<User> Follows { get; } = [];
}
