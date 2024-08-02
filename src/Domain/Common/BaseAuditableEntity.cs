namespace ByteShare.Domain.Common;

public abstract class BaseAuditableEntity<I, U> : BaseEntity<I>
{
    public DateTimeOffset Created { get; set; }
    public U? Creator { get; set; }
    public DateTimeOffset LastModified { get; set; }
    public U? LastModifier { get; set; }
}
