using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShare.Infrastructure.Persistence.Configuration;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder
        .Property(u => u.CreatorId)
        .IsRequired(false);

        builder
        .Property(u => u.LastModifierId)
        .IsRequired(false);

        builder
        .HasIndex(i => i.Name)
        .IsUnique();

        builder
        .HasOne<User>()
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
    }
}
