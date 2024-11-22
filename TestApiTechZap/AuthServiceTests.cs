using APITechZap.Data;
using APITechZap.Models.DTOs.UserDTOs;
using APITechZap.Models;
using APITechZap.Services.Authentication;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TestAPITechZap;

public class AuthServiceTests : IDisposable
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly ApplicationDbContext _dbContext;
    private readonly AuthService _authService;

    public AuthServiceTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        _dbContext = new ApplicationDbContext(options);

        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _authService = new AuthService(_dbContext, httpClient);
    }

    [Fact]
    public async Task RegisterAsync_ValidUser_ReturnsSuccessMessage()
    {
        // Arrange
        var request = new UserRegisterDTO
        {
            DsName = "Test",
            DsSurname = "User",
            DsEmail = "test@example.com",
            DsPassword = "Password123"
        };

        // Act
        var result = await _authService.RegisterAsync(request);

        // Assert
        Assert.Contains("Usuário cadastrado com sucesso", result);
    }

    [Fact]
    public async Task LoginAsync_InvalidCredentials_ThrowsArgumentException()
    {
        // Arrange
        var request = new UserLoginDTO
        {
            DsEmail = "",
            DsPassword = ""
        };

        // Act and Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _authService.LoginAsync(request));
    }
    /*
    [Fact]
    public async Task LoginAsync_ValidCredentials_ReturnsToken()
    {
        // Arrange
        var request = new UserLoginDTO
        {
            DsEmail = "test@example.com",
            DsPassword = "Password123"
        };

        var fakeResponse = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent("{\"IdToken\": \"fake_token\"}")
        };

        _httpMessageHandlerMock
            .Setup(handler => handler.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeResponse);

        // Act
        var result = await _authService.LoginAsync(request);

        // Assert
        Assert.Equal("fake_token", result);
    }*/

    [Fact]
    public async Task DeleteUserAsync_ExistingUser_ReturnsSuccessMessage()
    {
        // Arrange
        var user = new User
        {
            DsUidFirebase = "fake_uid",
            DsName = "Delete",
            DsSurname = "User",
            DsEmail = "delete@example.com",
            DsPassword = "Password123"
        };
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _authService.DeleteUserAsync(user.IdUser);

        // Assert
        Assert.Equal("Usuário deletado com sucesso", result);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
