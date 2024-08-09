using ByteShare.Domain.Entities;

namespace ByteShare.Application.Repository;

public interface IRecipeRepository : IRepository<Recipe, int?>
{
    Task<ICollection<Recipe>> GetUserRecipes(int userId);
}
