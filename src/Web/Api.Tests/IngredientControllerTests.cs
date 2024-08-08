using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using ByteShare.Web.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class IngredientControllerTests
{
    private readonly Mock<IRepository<Ingredient>> _mockRepo;
    private readonly IngredientController _controller;

    public IngredientControllerTests()
    {
        _mockRepo = new Mock<IRepository<Ingredient>>();
        _controller = new IngredientController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetIngredient_ReturnsOkResult()
    {
        var ingredient = new Ingredient { Id = 1, Name = "Salt" };
        _mockRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(ingredient);

        var result = await _controller.GetIngredient(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Ingredient>(okResult.Value);
        Assert.Equal(ingredient.Id, returnValue.Id);
        Assert.Equal(ingredient.Name, returnValue.Name);
    }

    [Fact]
    public async Task CreateIngredient_ReturnsOkResult()
    {
        var ingredient = new Ingredient { Id = 1, Name = "Pepper" };
        _mockRepo.Setup(repo => repo.Create(ingredient)).Returns(Task.CompletedTask);

        var result = await _controller.CreateIngredient(ingredient);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Ingredient>(okResult.Value);
        Assert.Equal(ingredient.Id, returnValue.Id);
        Assert.Equal(ingredient.Name, returnValue.Name);
    }

    [Fact]
    public async Task UpdateIngredient_ReturnsOkResult()
    {
        var ingredient = new Ingredient { Id = 1, Name = "Sugar" };
        _mockRepo.Setup(repo => repo.Update(ingredient)).Returns(Task.CompletedTask);

        var result = await _controller.UpdateIngredient(ingredient);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Ingredient>(okResult.Value);
        Assert.Equal(ingredient.Id, returnValue.Id);
        Assert.Equal(ingredient.Name, returnValue.Name);
    }

    [Fact]
    public async Task DeleteIngredient_ReturnsOkResult()
    {
        var ingredientId = 1;
        _mockRepo.Setup(repo => repo.Delete(ingredientId)).Returns(Task.CompletedTask);

        var result = await _controller.DeleteIngredient(ingredientId);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<int>(okResult.Value);
        Assert.Equal(ingredientId, returnValue);
    }

    [Fact]
    public async Task GetAllIngredients_ReturnsOkResult()
    {
        var ingredients = new List<Ingredient>
        {
            new Ingredient { Id = 1, Name = "Salt" },
            new Ingredient { Id = 2, Name = "Pepper" }
        };
        _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(ingredients);

        var result = await _controller.GetAllIngredients();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Ingredient>>(okResult.Value);

        Assert.Equal(ingredients.Count, returnValue.Count);

        foreach (var ingredient in ingredients)
        {
            var actual = returnValue.SingleOrDefault(i => i.Id == ingredient.Id);
            Assert.NotNull(actual);
            Assert.Equal(ingredient.Name, actual.Name);
        }
    }
}


// run test with:
// dotnet test --logger "console;verbosity=detailed"
// or 
// dotnet test