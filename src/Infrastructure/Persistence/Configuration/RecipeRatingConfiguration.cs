using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShare.Infrastructure.Persistence.Configuration;

public class RecipeRatingConfiguration : IEntityTypeConfiguration<RecipeRating>
{
    public void Configure(EntityTypeBuilder<RecipeRating> builder)
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

        builder
        .HasOne<Recipe>()
        .WithMany()
        .HasForeignKey(r => r.RecipeId);
    }
}
