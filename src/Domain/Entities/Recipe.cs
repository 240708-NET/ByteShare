using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class Recipe : BaseAuditableEntity<int?, User>
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Instructions { get; set; }
}
