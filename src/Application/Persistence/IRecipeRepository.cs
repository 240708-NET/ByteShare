using ByteShare.Domain.Entities;

namespace ByteShare.Application.Persistence;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<ICollection<Recipe>> GetUserRecipes(int userId);
}
