using Microsoft.EntityFrameworkCore;
using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShare.Infrastructure.Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
        .HasMany(u => u.Recipes)
        .WithOne(r => r.Creator)
        .IsRequired(true);

        builder
        .HasOne(u => u.Creator)
        .WithMany(u => u.UsersCreated);

        builder
        .HasOne(u => u.LastModifier)
        .WithMany(u => u.UsersModified);

        builder
        .HasMany(u => u.Follows)
        .WithMany(u => u.Followers);
    }
}
