using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class Rating : AuditableEntity<int?>
{
    public int RecipeId { get; set; }
    public int Value { get; set; }
}
