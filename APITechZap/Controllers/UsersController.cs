using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using APITechZap.Models;
using APITechZap.Models.DTOs;
using APITechZap.Repository;
using APITechZap.Services.Authentication;
using APITechZap.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace APITechZap.Controllers;

/// <summary>
/// Controller for user operations
/// </summary>
[Route("api/user")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    /// <summary>
    /// Constructor for UsersController
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="authService"></param>
    public UsersController(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    /// <summary>
    /// Login a request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO request)
    {
        try
        {
            var token = await _authService.LoginAsync(request);
            return Ok(token); // Return authentication token
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message); // Return unauthorized error
        }
    }

    /// <summary>
    /// Get all Users
    /// </summary>
    /// <returns>Return all Users</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return Ok(users);
    }

    /// <summary>
    /// Get a request by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound(); // Return 404 if request not found
        }

        return Ok(user);
    }

    /// <summary>
    /// Register a new request
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDTO request)
    {
        try
        {
            if (await _userRepository.EmailExistsAsync(request.DsEmail))
            {
                return BadRequest("O e-mail fornecido já está em uso.");
            }

            var result = await _authService.RegisterAsync(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Add additional data to a user
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="additionalData"></param>
    /// <returns></returns>
    [HttpPost("user-additional-data/{userId}")]
    public async Task<IActionResult> AddUserAdditionalData(int userId, [FromBody] UserAdditionalDataDTO additionalData)
    {
        try
        {
            var result = await _authService.AddUserAdditionalDataAsync(userId, additionalData);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Add address data to a user
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="address"></param>
    /// <returns></returns>
    [HttpPost("add-address/{userId}")]
    public async Task<IActionResult> AddAddress(int userId, [FromBody] AddressDTO address)
    {
        try
        {
            var result = await _authService.AddAddress(userId, address);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update a request
    /// </summary>
    /// <param name="email"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("update/{email}")]
    public async Task<IActionResult> UpdateUser(string email, [FromBody] UserUpdateDTO request)
    {
        try
        {
            var result = await _authService.UpdateUserByEmailAsync(email, request);
            return Ok(result); // Return success message
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); // Return error message
        }
    }

    /// <summary>
    /// Delete a request
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpDelete("delete/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        try
        {
            var result = await _authService.DeleteUserAsync(userId);
            return Ok(result); // Return success message
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); // Return error message
        }
    }

    /// <summary>
    /// Reactivate a request
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPost("reactivate/{userId}")]
    public async Task<IActionResult> ReactiveUser(int userId)
    {
        try
        {
            var result = await _authService.ReactiveUserAsync(userId);
            return Ok(result); // Return success message
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); // Return error message
        }
    }

    /// <summary>
    /// Forgot password
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] string email)
    {
        try
        {
            var response = await _authService.ForgotPasswordUserAsync(email);
            return Ok(response); // Return success message
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); // Return error message
        }
    }
}