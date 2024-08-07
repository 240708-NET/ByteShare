using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ByteShare.Domain.Common;

public abstract class BaseAuditableEntity<I, U> : BaseEntity<I>
{
    [JsonIgnore]
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public I? CreatorId { get; set; }
    [JsonIgnore]
    public DateTimeOffset LastModified { get; set; } = DateTimeOffset.UtcNow;
    public I? LastModifierId { get; set; }
}
