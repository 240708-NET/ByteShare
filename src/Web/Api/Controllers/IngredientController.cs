using ByteShare.Application.Repository;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.API.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientController(IRepository<Ingredient, int?> repository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredient(int id)
    {
        var ingredient = await repository.GetById(id);
        return Ok(ingredient);
    }

    [HttpPost]
    public async Task<IActionResult> CreateIngredient([FromBody] Ingredient ingredient)
    {
        await repository.Create(ingredient);
        return Ok(ingredient);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateIngredient([FromBody] Ingredient ingredient)
    {
        int updates = await repository.Update(ingredient);
        return updates == 1 ? Ok(): ValidationProblem();
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
