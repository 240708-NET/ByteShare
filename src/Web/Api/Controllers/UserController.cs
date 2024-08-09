using ByteShare.Application.Repository;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IUserRepository userRepository, IRecipeRepository recipeRepository, ILogger<UserController> logger) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await userRepository.GetById(id);
        return Ok(user);
    }

    [HttpGet("login")]
    public async Task<IActionResult> GetUser([FromQuery(Name="username")]string username, [FromQuery(Name="password")]string password)
    {
        // username = username.Trim('"');
        // password = password.Trim('"');
        var user = await userRepository.GetUserByUsernamePassword(username, password);
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
        int updates = await userRepository.Update(user);
        return updates == 1 ? Ok(): ValidationProblem();
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
