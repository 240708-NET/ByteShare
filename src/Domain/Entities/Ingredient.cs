using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class Ingredient : BaseAuditableEntity<int?, User>
{
    public required int RecipeId { get; set; }
    public required string Name { get; set; }
    public required float Amount { get; set; }
    public required string Unit { get; set; }
}
