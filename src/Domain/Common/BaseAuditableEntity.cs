using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ByteShare.Domain.Common;

public abstract class BaseAuditableEntity<I, U> : BaseEntity<I>
{
    [JsonIgnore]
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    [JsonIgnore]
    public U? Creator { get; set; }
    [JsonIgnore]
    public DateTimeOffset LastModified { get; set; } = DateTimeOffset.UtcNow;
    [JsonIgnore]
    public U? LastModifier { get; set; }
}
