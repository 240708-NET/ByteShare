using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.API.Controllers;

[ApiController]
[Route("api/recipe-ratings")]
public class RecipeRatingController(IRepository<RecipeRating> repository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipeRating(int id)
    {
        var recipeRating = await repository.GetById(id);
        return Ok(recipeRating);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecipeRating([FromBody] RecipeRating recipeRating)
    {
        await repository.Create(recipeRating);
        return Ok(recipeRating);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRecipeRating([FromBody] RecipeRating recipeRating)
    {
        await repository.Update(recipeRating);
        return Ok(recipeRating);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipeRating(int id)
    {
        await repository.Delete(id);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRecipeRatings()
    {
        var recipeRatings = await repository.GetAll();
        return Ok(recipeRatings);
    }
}
