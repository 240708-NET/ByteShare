using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ByteShare.Web.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IRepository<User> repository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await repository.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        await repository.Create(user);
        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        await repository.Update(user);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await repository.Delete(id);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await repository.GetAll();
        return Ok(users);
    }
}
