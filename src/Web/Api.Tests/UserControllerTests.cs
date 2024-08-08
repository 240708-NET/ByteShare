using System;
using Moq;
using Xunit;

public interface IUserService
{
    string GetUserName(int userId);
    bool UserExists(int userId);
}

public class UserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public string GetUserName(int userId)
    {
        if (_userService.UserExists(userId))
        {
            return _userService.GetUserName(userId);
        }
        return "User not found";
    }
}

public class UserControllerTests
{
    [Fact]
    public void ReturnsName_WhenExists()
    {
        var mockService = new Mock<IUserService>();
        mockService.Setup(s => s.UserExists(It.IsAny<int>())).Returns(true);
        mockService.Setup(s => s.GetUserName(It.IsAny<int>())).Returns("Mocked User Name");

        var controller = new UserController(mockService.Object);

        var result = controller.GetUserName(1);

        Assert.Equal("Mocked User Name", result);
    }

    [Fact]
    public void ReturnsNotFound_WhenDoesNotExist()
    {
        var mockService = new Mock<IUserService>();
        mockService.Setup(s => s.UserExists(It.IsAny<int>())).Returns(false);

        var controller = new UserController(mockService.Object);

        var result = controller.GetUserName(1);

        Assert.Equal("User not found", result);
    }

    [Theory]
    [InlineData(1, "Bilal")]
    [InlineData(2, "Bremer")]
    [InlineData(3, "Robert")]
    [InlineData(4, "Tamekia")]
    public void ReturnsName_ForUsers(int userId, string expectedName)
    {
        var mockService = new Mock<IUserService>();
        mockService.Setup(s => s.UserExists(It.IsAny<int>())).Returns(true);
        mockService.Setup(s => s.GetUserName(userId)).Returns(expectedName);

        var controller = new UserController(mockService.Object);

        var result = controller.GetUserName(userId);

        Assert.Equal(expectedName, result);
    }

    [Fact]
    public void ThrowsException_WhenServiceFails()
    {
        var mockService = new Mock<IUserService>();
        mockService.Setup(s => s.UserExists(It.IsAny<int>())).Throws(new Exception("Service error"));

        var controller = new UserController(mockService.Object);

        var exception = Assert.Throws<Exception>(() => controller.GetUserName(1));
        Assert.Equal("Service error", exception.Message);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(999999)]
    public void ReturnsNotFound_ForInvalidIds(int userId)
    {
        var mockService = new Mock<IUserService>();
        mockService.Setup(s => s.UserExists(userId)).Returns(false);

        var controller = new UserController(mockService.Object);

        var result = controller.GetUserName(userId);

        Assert.Equal("User not found", result);
    }

    [Fact]
    public void UserExists_CalledWithCorrectId()
    {
        var mockService = new Mock<IUserService>();
        var userId = 1;
        mockService.Setup(s => s.UserExists(userId)).Returns(true);

        var controller = new UserController(mockService.Object);

        controller.GetUserName(userId);

        mockService.Verify(s => s.UserExists(userId), Times.Once);
    }

    [Fact]
    public void GetUserName_ReturnsCorrectValue()
    {
        var mockService = new Mock<IUserService>();
        var userId = 1;
        var expectedName = "Tamekia Nelson";
        mockService.Setup(s => s.UserExists(userId)).Returns(true);
        mockService.Setup(s => s.GetUserName(userId)).Returns(expectedName);

        var controller = new UserController(mockService.Object);

        var result = controller.GetUserName(userId);

        Assert.Equal(expectedName, result);
    }
}


// run test with:
// dotnet test --logger "console;verbosity=detailed"
// or 
// dotnet test