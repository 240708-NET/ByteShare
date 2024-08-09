using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class Ingredient : AuditableEntity<int?>
{
    public int? RecipeId { get; set; }
    public required string Name { get; set; }
    public required float Amount { get; set; }
    public required string Unit { get; set; }
}
