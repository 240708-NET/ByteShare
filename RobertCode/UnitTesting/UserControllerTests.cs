public class UsersControllerTests
{
    private readonly UsersController _controller;
    private readonly Mock<IRepository<User>> _mockRepository;

    public UsersControllerTests()
    {
        _mockRepository = new Mock<IRepository<User>>();
        _controller = new UsersController(_mockRepository.Object);
    }

    [Fact]
    public async Task GetUsers_ReturnsOkResult_WithAListOfUsers()
    {
        _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GetTestUsers());

        var result = await _controller.GetUsers();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<User>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    private List<User> GetTestUsers()
    {
        return new List<User>
        {
            new User { UserID = 1, Username = "User1", Email = "user1@example.com" },
            new User { UserID = 2, Username = "User2", Email = "user2@example.com" }
        };
    }
}