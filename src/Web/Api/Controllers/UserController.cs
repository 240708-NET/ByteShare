using ByteShare.Application.Repository;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.Api.Controllers;

[ApiController]
[Route("api")]
public class UserController(IUserRepository repository) : ControllerBase
{

    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await repository.GetUser(id);
        return Ok(user);
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        var id = await repository.CreateUser(user);
        return Ok(id);
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await repository.GetAllUsers();
        return Ok(users);
    }

}
