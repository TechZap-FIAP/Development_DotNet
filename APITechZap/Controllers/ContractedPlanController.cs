using APITechZap.Models;
using APITechZap.Models.DTOs;
using APITechZap.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITechZap.Controllers;

/// <summary>
/// Controller para os planos contratados
/// </summary>
[Route("api/contracted-plan")]
[ApiController]
[Tags("Plano Contratado")]
public class ContractedPlanController : ControllerBase
{
    private readonly IContractedPlanRepository _contractedPlanRepository;

    /// <summary>
    /// Construtor da classe que recebe o repositório de planos contratados
    /// </summary>
    /// <param name="contractedPlanRepository"></param>
    public ContractedPlanController(IContractedPlanRepository contractedPlanRepository)
    {
        _contractedPlanRepository = contractedPlanRepository;
    }

    /// <summary>
    /// Adiciona um plano contratado ao banco de dados
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="planDto"></param>
    /// <returns></returns>
    [HttpPost("add-contracted-plan/{userId}")]
    public async Task<IActionResult> AddContractedPlan(int userId, [FromBody] ContractedPlanDTO planDto)
    {
        try
        {
            var plan = new ContractedPlan
            {
                IdSolarPanel = planDto.IdSolarPanel,
                IdWindTurbine = planDto.IdWindTurbine,
            };

            var response = await _contractedPlanRepository.AddContractedPlanAsync(userId, plan);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retorna os planos contratados de um usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("get-contracted-plan/{userId}")]
    public async Task<IActionResult> GetContractedPlan(int userId)
    {
        try
        {
            var response = await _contractedPlanRepository.GetPlansByUserIdAsync(userId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("del-contracted-plan/{planId}")]
    public async Task<IActionResult> DeleteContractedPlan(int planId)
    {
        try
        {
            var response = await _contractedPlanRepository.DeleteContractedPlanAsync(planId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
