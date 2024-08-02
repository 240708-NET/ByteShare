using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    DbSet<User> Users { get; set; }
    DbSet<RecipeRating> RecipeRatings { get; set; }
    DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    DbSet<Recipe> Recipes { get; set; }
    DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
        .HasMany(user => user.Recipes)
        .WithOne(recipe => recipe.Creator)
        .IsRequired(true);

        builder.Entity<User>()
        .HasMany(user => user.RecipeRatings)
        .WithOne(recipeRating => recipeRating.Creator);

        builder.Entity<User>()
        .HasOne(user => user.Creator)
        .WithMany(user => user.UsersCreated);

        builder.Entity<User>()
        .HasOne(user => user.LastModifier)
        .WithMany(user => user.UsersModified);

        builder.Entity<User>()
        .HasMany(user => user.Follows)
        .WithMany(user => user.Followers);

        base.OnModelCreating(builder);
    }
}
