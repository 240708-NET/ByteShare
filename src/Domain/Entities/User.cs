using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class User : BaseAuditableEntity<int, User>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public ICollection<Recipe> Recipes { get; } = [];
    public ICollection<RecipeRating> RecipeRatings { get; } = [];
    public ICollection<User> UsersCreated { get; } = [];
    public ICollection<User> UsersModified { get; } = [];
    public ICollection<User> Followers { get; } = [];
    public ICollection<User> Follows { get; } = [];
}
