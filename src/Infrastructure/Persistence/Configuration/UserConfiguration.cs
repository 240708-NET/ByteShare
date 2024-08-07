using Microsoft.EntityFrameworkCore;
using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShare.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
        .Property(u => u.CreatorId)
        .IsRequired(false);

        builder
        .Property(u => u.LastModifierId)
        .IsRequired(false);

        builder.HasOne<User>()
        .WithMany()
        .HasForeignKey(u => u.CreatorId)
        .OnDelete(DeleteBehavior.NoAction)
        .IsRequired(false);

        builder
        .HasOne<User>()
        .WithMany()
        .HasForeignKey(u => u.LastModifierId)
        .OnDelete(DeleteBehavior.NoAction)
        .IsRequired(false);

        builder
        .HasMany(u => u.Follows)
        .WithMany(u => u.Followers);
    }
}
