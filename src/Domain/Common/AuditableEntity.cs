using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ByteShare.Domain.Common;

public abstract class AuditableEntity<T> : BaseEntity<T>
{
    [JsonIgnore]
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public T? CreatorId { get; set; }
    [JsonIgnore]
    public DateTimeOffset LastModified { get; set; } = DateTimeOffset.UtcNow;
    public T? LastModifierId { get; set; }
}
