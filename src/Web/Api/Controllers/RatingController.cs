using ByteShare.Application.Repository;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.API.Controllers;

[ApiController]
[Route("api/recipe-ratings")]
public class RatingController(IRepository<Rating, int> repository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRating(int id)
    {
        var rating = await repository.GetById(id);
        return Ok(rating);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRating([FromBody] Rating rating)
    {
        await repository.Create(rating);
        return Ok(rating);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRating([FromBody] Rating rating)
    {
        await repository.Update(rating);
        return Ok(rating);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRating(int id)
    {
        await repository.Delete(id);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRatings()
    {
        var ratings = await repository.GetAll();
        return Ok(ratings);
    }
}
