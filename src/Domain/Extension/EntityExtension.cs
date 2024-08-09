using ByteShare.Domain.Common;
using ByteShare.Domain.Entities;

namespace ByteShare.Domain.Extension;

public static class AuditableEntityExtension
{
    public static void CopyUserIfNull(this AuditableEntity<int?> target, AuditableEntity<int?> source)
    {
            target.CreatorId ??= source.CreatorId;
            target.LastModifierId ??= target.LastModifierId;
    }

    public static void CopyUserIfNull(this ICollection<Ingredient> target, AuditableEntity<int?> source)
    {
        foreach(var ingredient in target)
        {
            ingredient.CopyUserIfNull(source);
        }
    }

}