namespace ByteShare.Domain.Common;

public abstract class BaseEntity<I>
{
        public required I Id {get; set;}
}
