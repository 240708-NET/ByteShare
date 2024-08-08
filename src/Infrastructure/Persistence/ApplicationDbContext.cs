using ByteShare.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
        .ApplyConfiguration(new UserConfiguration())
        .ApplyConfiguration(new RecipeConfiguration())
        .ApplyConfiguration(new RatingConfiguration())
        .ApplyConfiguration(new IngredientConfiguration());

        base.OnModelCreating(builder);
    }
}
