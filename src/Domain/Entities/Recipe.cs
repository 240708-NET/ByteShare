using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class Recipe : AuditableEntity<int?>
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Instructions { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; } = [];
}
