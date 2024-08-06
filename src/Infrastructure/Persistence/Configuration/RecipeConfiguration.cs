using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShare.Infrastructure.Persistence.Configuration;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder
        .HasOne(r => r.Creator)
        .WithMany(u => u.Recipes);

        // builder
        // .HasOne(r => r.LastModifier)
        // .WithMany(u => u.Recipes);

        builder
        .HasMany(r => r.RecipeIngredients)
        .WithOne(i => i.Recipe);
    }
}
