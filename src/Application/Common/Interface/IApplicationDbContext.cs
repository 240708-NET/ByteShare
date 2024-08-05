using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Application.Common.Interface;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<RecipeRating> RecipeRatings { get; set; }
    DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    DbSet<Recipe> Recipes { get; set; }
    DbSet<Ingredient> Ingredients { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
