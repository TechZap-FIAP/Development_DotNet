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
    /// <param name="aiService">Serviço de IA</param>
    public AiController(IAiService aiService)
    {
        _aiService = aiService;
    }

    /// <summary>
    /// Suporte para ajuda ao usuário
    /// </summary>
    /// <param name="input">Entrada de texto para a IA</param>
    /// <returns></returns>
    /// <response code="200">Resposta gerada com sucesso.</response>
    /// <response code="400">Entrada inválida.</response>
    /// <response code="500">Erro ao processar a solicitação.</response>
    [HttpGet]
    public async Task<IActionResult> TriggerOpenAI([FromQuery] string input)
    {
        var response = await _aiService.TriggerOpenAI(input);
        return Ok(response);
    }
}
