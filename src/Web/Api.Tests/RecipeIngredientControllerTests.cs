using System.Collections.Generic;
using System.Threading.Tasks;
using ByteShare.Application.Persistence;
using ByteShare.Domain.Entities;
using ByteShare.Web.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Tests
{
    public class RecipeIngredientControllerTests
    {
        private readonly Mock<IRepository<RecipeIngredient>> _mockRepo;
        private readonly RecipeIngredientController _controller;

        public RecipeIngredientControllerTests()
        {
            _mockRepo = new Mock<IRepository<RecipeIngredient>>();
            _controller = new RecipeIngredientController(_mockRepo.Object);
        }

        [Fact]
        public async Task Get_ReturnsOk_WithIngredient()
        {
            var ingredient = new RecipeIngredient
            {
                Id = 1,
                RecipeId = 100,
                IngredientId = 200,
                Quantity = 2.5f,
                Unit = "grams"
            };
            _mockRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(ingredient);

            var result = await _controller.GetRecipeIngredient(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<RecipeIngredient>(okResult.Value);
            Assert.Equal(ingredient.Id, returnValue.Id);
            Assert.Equal(ingredient.RecipeId, returnValue.RecipeId);
            Assert.Equal(ingredient.IngredientId, returnValue.IngredientId);
            Assert.Equal(ingredient.Quantity, returnValue.Quantity);
            Assert.Equal(ingredient.Unit, returnValue.Unit);
        }

        [Fact]
        public async Task Create_ReturnsOk_WithIngredient()
        {
            var ingredient = new RecipeIngredient
            {
                Id = 1,
                RecipeId = 100,
                IngredientId = 200,
                Quantity = 2.5f,
                Unit = "grams"
            };
            _mockRepo.Setup(repo => repo.Create(ingredient)).Returns(Task.CompletedTask);

            var result = await _controller.CreateRecipeIngredient(ingredient);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<RecipeIngredient>(okResult.Value);
            Assert.Equal(ingredient.Id, returnValue.Id);
            Assert.Equal(ingredient.RecipeId, returnValue.RecipeId);
            Assert.Equal(ingredient.IngredientId, returnValue.IngredientId);
            Assert.Equal(ingredient.Quantity, returnValue.Quantity);
            Assert.Equal(ingredient.Unit, returnValue.Unit);
        }

        [Fact]
        public async Task Update_ReturnsOk_WithIngredient()
        {
            var ingredient = new RecipeIngredient
            {
                Id = 1,
                RecipeId = 100,
                IngredientId = 200,
                Quantity = 3.0f,
                Unit = "liters"
            };
            _mockRepo.Setup(repo => repo.Update(ingredient)).Returns(Task.CompletedTask);

            var result = await _controller.UpdateRecipeIngredient(ingredient);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<RecipeIngredient>(okResult.Value);
            Assert.Equal(ingredient.Id, returnValue.Id);
            Assert.Equal(ingredient.RecipeId, returnValue.RecipeId);
            Assert.Equal(ingredient.IngredientId, returnValue.IngredientId);
            Assert.Equal(ingredient.Quantity, returnValue.Quantity);
            Assert.Equal(ingredient.Unit, returnValue.Unit);
        }

        [Fact]
        public async Task Delete_ReturnsOk_WithId()
        {
            var id = 1;
            _mockRepo.Setup(repo => repo.Delete(id)).Returns(Task.CompletedTask);

            var result = await _controller.DeleteRecipeIngredient(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<int>(okResult.Value);
            Assert.Equal(id, returnValue);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WithIngredients()
        {
            var ingredients = new List<RecipeIngredient>
            {
                new RecipeIngredient
                {
                    Id = 1,
                    RecipeId = 100,
                    IngredientId = 200,
                    Quantity = 2.5f,
                    Unit = "grams"
                },
                new RecipeIngredient
                {
                    Id = 2,
                    RecipeId = 101,
                    IngredientId = 201,
                    Quantity = 1.0f,
                    Unit = "cups"
                }
            };
            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(ingredients);

            var result = await _controller.GetAllRecipeIngredients();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<RecipeIngredient>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
            Assert.Contains(returnValue, ri => ri.Id == 1 && ri.RecipeId == 100 && ri.IngredientId == 200 && ri.Quantity == 2.5f && ri.Unit == "grams");
            Assert.Contains(returnValue, ri => ri.Id == 2 && ri.RecipeId == 101 && ri.IngredientId == 201 && ri.Quantity == 1.0f && ri.Unit == "cups");
        }
    }
}



// run test with:
// dotnet test --logger "console;verbosity=detailed"
// or 
// dotnet test