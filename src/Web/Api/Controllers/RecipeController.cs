using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.Api.Controllers;

[ApiController]
[Route("api")]
public class RecipeController(IRepository<Recipe> repository) : ControllerBase
{
    [HttpGet("recipes/{id}")]
    public async Task<IActionResult> GetRecipes(int id)
    {
        var recipe = await repository.GetById(id);
        return Ok(recipe);
    }

    [HttpPost("recipes")]
    public async Task<IActionResult> CreateRecipe([FromBody] Recipe recipe)
    {
        await repository.Create(recipe);
        return Ok(recipe);
    }

    [HttpGet("recipes")]
    public async Task<IActionResult> GetAllRecipes()
    {
        var recipes = await repository.GetAll();
        return Ok(recipes);
    }
}
