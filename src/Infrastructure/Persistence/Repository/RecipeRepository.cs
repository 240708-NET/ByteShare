using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ByteShare.Infrastructure.Persistence;

public class RecipeRepository(ApplicationDbContext context) : Repository<Recipe>(context), IRecipeRepository
{
    public async Task<ICollection<Recipe>> GetUserRecipes(int userId)
    {
        return await dbSet.Where(r => r.CreatorId == userId).ToListAsync();
    }
}
