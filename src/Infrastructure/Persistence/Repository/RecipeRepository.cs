using ByteShare.Application.Repository;
using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure.Persistence.Repository;

public class RecipeRepository : GenericRepository<Recipe, int?>, IRecipeRepository
{
    public RecipeRepository(ApplicationDbContext context) : base(context) {}

    public override async Task<Recipe?> GetById(int? id)
    {
        return await dbSet
                    .Where(r => r.Id == id)
                    .Include(r => r.Ingredients)
                    .SingleOrDefaultAsync();
    }

    public override async Task<ICollection<Recipe>> GetAll()
    {
        return await dbSet
                    .Include(r => r.Ingredients)
                    .ToListAsync();
    }

    public async Task<ICollection<Recipe>> GetUserRecipes(int userId)
    {
        return await dbSet
                    .Where(r => r.CreatorId == userId)
                    .Include(r => r.Ingredients)
                    .ToListAsync();
    }
}
