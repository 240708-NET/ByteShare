using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class RecipeIngredient : BaseAuditableEntity<int, User>
{
    public required Recipe Recipe { get; set; }
    public required Ingredient Ingredient { get; set; }
    public float Quantity { get; set; }
    public required string Unit { get; set; }
}
