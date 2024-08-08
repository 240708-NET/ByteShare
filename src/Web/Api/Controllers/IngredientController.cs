using ByteShare.Application.Repository;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.API.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientController(IRepository<Ingredient, int> repository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredient(int id)
    {
        var recipeIngredient = await repository.GetById(id);
        return Ok(recipeIngredient);
    }

    [HttpPost]
    public async Task<IActionResult> CreateIngredient([FromBody] Ingredient ingredient)
    {
        await repository.Create(ingredient);
        return Ok(ingredient);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateIngredient([FromBody] Ingredient Ingredient)
    {
        await repository.Update(Ingredient);
        return Ok(Ingredient);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredient(int id)
    {
        await repository.Delete(id);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllIngredients()
    {
        var ingredients = await repository.GetAll();
        return Ok(ingredients);
    }
}
