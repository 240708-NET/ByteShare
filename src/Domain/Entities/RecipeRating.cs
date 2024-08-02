using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class RecipeRating : BaseAuditableEntity<int, User>
{
    public required Recipe Recipe { get; set; }
    public int Value { get; set; }
}
