using APITechZap.Models.DTOs;
using APITechZap.Services.ArtificialIntelligence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITechZap.Controllers;

/// <summary>
/// Controller for AI service
/// </summary>
[Route("api/support")]
[ApiController]
[Tags("IA de Suporte")]
public class AiController : ControllerBase
{
    private readonly IAiService _aiService;

    /// <summary>
    /// Constructor for AiController
    /// </summary>
    /// <param name="aiService"></param>
    public AiController(IAiService aiService)
    {
        _aiService = aiService;
    }

    /// <summary>
    /// Suporte para ajuda ao usuário
    /// </summary>
    /// <param name="userQuery"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> GenerateResponse([FromBody] UserQueryDTO userQuery)
    {
        if (string.IsNullOrWhiteSpace(userQuery?.Query))
            return BadRequest("A consulta não pode estar vazia.");

        var response = await _aiService.GetApplicationHelpAsync(userQuery.Query);

        return Ok(new { response });
    }
}
