using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShare.Infrastructure.Persistence.Configuration;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder
        .HasOne(r => r.Creator)
        .WithMany(u => u.Ingredients);

        // builder
        // .HasOne(r => r.LastModifier)
        // .WithMany(u => u.Ingredients);
    }
}
