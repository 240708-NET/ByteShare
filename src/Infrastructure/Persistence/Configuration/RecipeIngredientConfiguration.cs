using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShare.Infrastructure.Persistence.Configuration;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder
        .Property(u => u.CreatorId)
        .IsRequired(false);

        builder
        .Property(u => u.LastModifierId)
        .IsRequired(false);
 
        builder
        .HasOne<User>()
        .WithMany()
        .HasForeignKey(r => r.CreatorId)
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
