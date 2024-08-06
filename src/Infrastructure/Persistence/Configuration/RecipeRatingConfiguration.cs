using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShare.Infrastructure.Persistence.Configuration;

public class RecipeRatingConfiguration : IEntityTypeConfiguration<RecipeRating>
{
    public void Configure(EntityTypeBuilder<RecipeRating> builder)
    {
        builder
        .HasOne(r => r.Creator)
        .WithMany(u => u.RecipeRatings);

        // builder
        // .HasOne(r => r.LastModifier)
        // .WithMany(u => u.RecipeRatings);
    }
}
