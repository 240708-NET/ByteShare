using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class RecipeIngredient : BaseAuditableEntity<int?, User>
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public float Quantity { get; set; }
    public required string Unit { get; set; }
}
