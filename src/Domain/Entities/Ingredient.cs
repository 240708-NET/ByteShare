using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class Ingredient : BaseAuditableEntity<int, User>
{
    public required string Name { get; set; }
    public ICollection<RecipeIngredient> RecipeIngredients { get; } = [];
}
