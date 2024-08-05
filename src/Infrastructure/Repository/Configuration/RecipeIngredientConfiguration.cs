using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShare.Infrastructure.Repository.Configuration;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder
        .HasOne(r => r.Creator)
        .WithMany(u => u.RecipeIngredients);

        // builder
        // .HasOne(r => r.LastModifier)
        // .WithMany(u => u.RecipeIngredients);

        builder
        .HasOne(i => i.Ingredient)
        .WithMany(r => r.RecipeIngredients);
    }
}
