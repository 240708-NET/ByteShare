using System.Collections.Generic;
using System.Threading.Tasks;
using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using ByteShare.Web.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class RecipeRatingControllerTests
{
    private readonly Mock<IRepository<RecipeRating>> _mockRepo;
    private readonly RecipeRatingController _controller;

    public RecipeRatingControllerTests()
    {
        _mockRepo = new Mock<IRepository<RecipeRating>>();
        _controller = new RecipeRatingController(_mockRepo.Object);
    }

    [Fact]
    public async Task Get_ReturnsOk_WithRating()
    {
        var rating = new RecipeRating { Id = 1, RecipeId = 100, Value = 5 };
        _mockRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(rating);

        var result = await _controller.GetRecipeRating(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<RecipeRating>(okResult.Value);
        Assert.Equal(rating.Id, returnValue.Id);
        Assert.Equal(rating.RecipeId, returnValue.RecipeId);
        Assert.Equal(rating.Value, returnValue.Value);
    }

    [Fact]
    public async Task Create_ReturnsOk_WithRating()
    {
        var rating = new RecipeRating { Id = 1, RecipeId = 100, Value = 5 };
        _mockRepo.Setup(repo => repo.Create(rating)).Returns(Task.CompletedTask);

        var result = await _controller.CreateRecipeRating(rating);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<RecipeRating>(okResult.Value);
        Assert.Equal(rating.Id, returnValue.Id);
        Assert.Equal(rating.RecipeId, returnValue.RecipeId);
        Assert.Equal(rating.Value, returnValue.Value);
    }

    [Fact]
    public async Task Update_ReturnsOk_WithRating()
    {
        var rating = new RecipeRating { Id = 1, RecipeId = 100, Value = 4 };
        _mockRepo.Setup(repo => repo.Update(rating)).Returns(Task.CompletedTask);

        var result = await _controller.UpdateRecipeRating(rating);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<RecipeRating>(okResult.Value);
        Assert.Equal(rating.Id, returnValue.Id);
        Assert.Equal(rating.RecipeId, returnValue.RecipeId);
        Assert.Equal(rating.Value, returnValue.Value);
    }

    [Fact]
    public async Task Delete_ReturnsOk_WithId()
    {
        var id = 1;
        _mockRepo.Setup(repo => repo.Delete(id)).Returns(Task.CompletedTask);

        var result = await _controller.DeleteRecipeRating(id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<int>(okResult.Value);
        Assert.Equal(id, returnValue);
    }

    [Fact]
    public async Task GetAll_ReturnsOk_WithRatings()
    {
        var ratings = new List<RecipeRating>
        {
            new RecipeRating { Id = 1, RecipeId = 100, Value = 5 },
            new RecipeRating { Id = 2, RecipeId = 101, Value = 4 },
            new RecipeRating { Id = 3, RecipeId = 102, Value = 3 },
            new RecipeRating { Id = 4, RecipeId = 103, Value = 2 }
        };
        _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(ratings);

        var result = await _controller.GetAllRecipeRatings();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<RecipeRating>>(okResult.Value);
        Assert.Equal(4, returnValue.Count);
        Assert.Contains(returnValue, rr => rr.Id == 1 && rr.RecipeId == 100 && rr.Value == 5);
        Assert.Contains(returnValue, rr => rr.Id == 2 && rr.RecipeId == 101 && rr.Value == 4);
        Assert.Contains(returnValue, rr => rr.Id == 3 && rr.RecipeId == 102 && rr.Value == 3);
        Assert.Contains(returnValue, rr => rr.Id == 4 && rr.RecipeId == 103 && rr.Value == 2);
    }
}


// run test with:
// dotnet test --logger "console;verbosity=detailed"
// or 
// dotnet test