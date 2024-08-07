using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.API.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipeController(IRepository<Recipe> repository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipe(int id)
    {
        var recipe = await repository.GetById(id);
        return Ok(recipe);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecipe([FromBody] Recipe recipe)
    {
        await repository.Create(recipe);
        return Ok(recipe);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRecipe([FromBody] Recipe recipe)
    {
        await repository.Update(recipe);
        return Ok(recipe);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        await repository.Delete(id);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRecipes()
    {
        var recipes = await repository.GetAll();
        return Ok(recipes);
    }
}
