using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class Rating : BaseAuditableEntity<int?, User>
{
    public int RecipeId { get; set; }
    public int Value { get; set; }
}
