using APITechZap.Models;
using APITechZap.Models.DTOs.ContractedPlanDTOs;
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
    /// <param name="contractedPlanRepository">Repositório de planos contratados</param>
    public ContractedPlanController(IContractedPlanRepository contractedPlanRepository)
    {
        _contractedPlanRepository = contractedPlanRepository;
    }

    /// <summary>
    /// Adiciona um plano contratado ao banco de dados
    /// </summary>
    /// <param name="userId">ID do usuário que contratou o plano</param>
    /// <param name="planDto">Dados do plano a ser adicionado</param>
    /// <returns></returns>
    /// <response code="200">Plano contratado adicionado com sucesso.</response>
    /// <response code="400">Erro ao adicionar plano contratado.</response>
    /// <response code="500">Erro interno ao processar a solicitação.</response>
    [HttpPost("{userId}")]
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
    /// <param name="userId">ID do usuário cujos planos serão retornados</param>
    /// <returns></returns>
    /// <response code="200">Planos encontrados com sucesso.</response>
    /// <response code="400">Planos não encontrados</response>
    /// <response code="500">Erro ao buscar os planos</response>
    [HttpGet("{userId}")]
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

    /// <summary>
    /// Remove um plano contratado do banco de dados
    /// </summary>
    /// <param name="planId">ID do plano a ser removido</param>
    /// <returns></returns>
    /// <response code="200">Plano contratado removido com sucesso.</response>
    /// <response code="400">Erro ao remover plano contratado.</response>
    /// <response code="500">Erro interno ao processar a solicitação.</response>
    [HttpDelete("{planId}")]
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
