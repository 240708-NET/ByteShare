using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShare.Infrastructure.Persistence.Configuration;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
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

        // builder
        // .HasMany<Ingredient>()
        // .WithMany()
        // .UsingEntity<RecipeIngredient>(
        //     // l => l.HasOne<Ingredient>().WithMany().HasForeignKey(rI => rI.IngredientId),
        //     // r => r.HasOne<Recipe>().WithMany().HasForeignKey(rI => rI.RecipeId)
        // );
    }
}
