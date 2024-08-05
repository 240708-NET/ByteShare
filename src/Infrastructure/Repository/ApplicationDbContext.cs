using ByteShare.Application.Common.Interface;
using ByteShare.Domain.Entities;
using ByteShare.Infrastructure.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure.Repository;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<RecipeRating> RecipeRatings { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
        .ApplyConfiguration<User>(new UserConfiguration())
        .ApplyConfiguration<Recipe>(new RecipeConfiguration())
        .ApplyConfiguration<RecipeRating>(new RecipeRatingConfiguration())
        .ApplyConfiguration<RecipeIngredient>(new RecipeIngredientConfiguration())
        .ApplyConfiguration<Ingredient>(new IngredientConfiguration());

        base.OnModelCreating(builder);
    }
}
