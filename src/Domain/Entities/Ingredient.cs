using ByteShare.Domain.Common;

namespace ByteShare.Domain.Entities;

public class Ingredient : BaseAuditableEntity<int?, User>
{
    private string? _name;
    public required string? Name
    {
        get => _name;
        set => _name = value?.Trim().ToLower();
    }
}
