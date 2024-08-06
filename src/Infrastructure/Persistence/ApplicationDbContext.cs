//using ByteShare.Application.Common.Interface;
using ByteShare.Domain.Entities;
using ByteShare.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
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
