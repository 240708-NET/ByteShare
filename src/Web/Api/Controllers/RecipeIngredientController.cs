using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.API.Controllers;

[ApiController]
[Route("api/recipe-ingredients")]
public class RecipeIngredientController(IRepository<RecipeIngredient> repository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipeIngredient(int id)
    {
        var recipeIngredient = await repository.GetById(id);
        return Ok(recipeIngredient);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecipeIngredient([FromBody] RecipeIngredient recipeIngredient)
    {
        await repository.Create(recipeIngredient);
        return Ok(recipeIngredient);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRecipeIngredient([FromBody] RecipeIngredient recipeIngredient)
    {
        await repository.Update(recipeIngredient);
        return Ok(recipeIngredient);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipeIngredient(int id)
    {
        await repository.Delete(id);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRecipeIngredients()
    {
        var recipeIngredients = await repository.GetAll();
        return Ok(recipeIngredients);
    }
}
