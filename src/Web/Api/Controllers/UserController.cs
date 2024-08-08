using ByteShare.Application.Repository;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IRepository<User, int> userRepository, IRecipeRepository recipeRepository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await userRepository.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        await userRepository.Create(user);
        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        await userRepository.Update(user);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await userRepository.Delete(id);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userRepository.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}/recipes")]
    public async Task<IActionResult> GetUserRecipes(int id)
    {
        var recipes = await recipeRepository.GetUserRecipes(id);
        return Ok(recipes);
    }
}
