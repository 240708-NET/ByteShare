using System.Collections.Generic;
using System.Threading.Tasks;
using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using ByteShare.Web.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class RecipeControllerTests
{
    private readonly Mock<IRecipeRepository> _mockRepo;
    private readonly RecipeController _controller;

    public RecipeControllerTests()
    {
        _mockRepo = new Mock<IRecipeRepository>();
        _controller = new RecipeController(_mockRepo.Object);
    }

    [Fact]
    public async Task Get_ReturnsOk_WithRecipe()
    {
        var recipe = new Recipe { Id = 1, Title = "Test Recipe", Instructions = "Mix ingredients" };
        _mockRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(recipe);

        var result = await _controller.GetRecipe(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Recipe>(okResult.Value);
        Assert.Equal(recipe.Id, returnValue.Id);
        Assert.Equal(recipe.Title, returnValue.Title);
        Assert.Equal(recipe.Instructions, returnValue.Instructions);
    }

    [Fact]
    public async Task Create_ReturnsOk_WithRecipe()
    {
        var recipe = new Recipe { Id = 1, Title = "New Recipe", Instructions = "Bake for 30 minutes" };
        _mockRepo.Setup(repo => repo.Create(recipe)).Returns(Task.CompletedTask);

        var result = await _controller.CreateRecipe(recipe);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Recipe>(okResult.Value);
        Assert.Equal(recipe.Id, returnValue.Id);
        Assert.Equal(recipe.Title, returnValue.Title);
        Assert.Equal(recipe.Instructions, returnValue.Instructions);
    }

    [Fact]
    public async Task Update_ReturnsOk_WithRecipe()
    {
        var recipe = new Recipe { Id = 1, Title = "Updated Recipe", Instructions = "Grill for 20 minutes" };
        _mockRepo.Setup(repo => repo.Update(recipe)).Returns(Task.CompletedTask);

        var result = await _controller.UpdateRecipe(recipe);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Recipe>(okResult.Value);
        Assert.Equal(recipe.Id, returnValue.Id);
        Assert.Equal(recipe.Title, returnValue.Title);
        Assert.Equal(recipe.Instructions, returnValue.Instructions);
    }

    [Fact]
    public async Task Delete_ReturnsOk_WithId()
    {
        var id = 1;
        _mockRepo.Setup(repo => repo.Delete(id)).Returns(Task.CompletedTask);

        var result = await _controller.DeleteRecipe(id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<int>(okResult.Value);
        Assert.Equal(id, returnValue);
    }

    [Fact]
    public async Task GetAll_ReturnsOk_WithRecipes()
    {
        var recipes = new List<Recipe>
        {
            new Recipe { Id = 1, Title = "Recipe 1", Instructions = "Cook for 10 minutes" },
            new Recipe { Id = 2, Title = "Recipe 2", Instructions = "Boil for 20 minutes" }
        };
        _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(recipes);

        var result = await _controller.GetAllRecipes();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Recipe>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
        Assert.Contains(returnValue, r => r.Id == 1 && r.Title == "Recipe 1" && r.Instructions == "Cook for 10 minutes");
        Assert.Contains(returnValue, r => r.Id == 2 && r.Title == "Recipe 2" && r.Instructions == "Boil for 20 minutes");
    }
}


// run test with:
// dotnet test --logger "console;verbosity=detailed"
// or 
// dotnet test