using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using APITechZap.Models;
using APITechZap.Repository;
using APITechZap.Services.Authentication;
using APITechZap.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using APITechZap.Models.DTOs.AddressDTOs;
using APITechZap.Models.DTOs.UserAdditionalDataDTOs;
using APITechZap.Models.DTOs.UserDTOs;

namespace APITechZap.Controllers;

/// <summary>
/// Controller for user operations
/// </summary>
[Route("api/user")]
[ApiController]
[Tags("Usuário")]
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
    public async Task<ActionResult<IEnumerable<UserDetailedDTO>>> GetAllUsers()
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
    public async Task<ActionResult<UserDetailedDTO>> GetUserById(int id)
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
    /// Update a request
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <response code="200">Usuário atualizado com sucesso.</response>
    /// <response code="400">Erro ao atualizar usuário.</response>
    /// <response code="404">Usuário não encontrado.</response>
    /// <response code="500">Erro ao atualizar usuário.</response>
    [HttpPut("update/{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserUpdateDTO request)
    {
        try
        {
            var result = await _authService.UpdateUserByIdAsync(userId, request);
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
    /// <response code="200">Usuário excluído com sucesso.</response>
    /// <response code="404">Usuário não encontrado.</response>
    /// <response code="500">Erro ao excluir usuário.</response>
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
    /// <response code="200">Usuário reativado com sucesso.</response>
    /// <response code="404">Usuário não encontrado.</response>
    /// <response code="500">Erro ao reativar usuário.</response>
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
    /// Redefine a senha pelo E-mail
    /// </summary>
    /// <param name="actualEmail">O E-mail do usuário a ser enviado o link de redefinição.</param>
    /// <returns>Uma mensagem de sucesso.</returns>
    /// <response code="200">Link Enviado com sucesso.</response>
    /// <response code="404">Usuário não encontrado.</response>
    /// <response code="500">Erro ao enviar e-mail de redefinição de senha.</response>
    [HttpPost("forgot-password/{actualEmail}")]
    public async Task<ActionResult<string>> ForgotPassword(string actualEmail)
    {
        try
        {
            var result = await _authService.ForgotPasswordUserAsync(actualEmail);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}