using APITechZap.Models.DTOs.SolarPanelDTOs;
using APITechZap.Models.DTOs.WindTurbineDTOs;

namespace APITechZap.Models.DTOs.ContractedPlanDTOs;

/// <summary>
/// DTO para detalhes de um plano contratado
/// </summary>
public class ContractedPlanDetailedDTO
{
    /// <summary>
    /// Dados do Painel Solar
    /// </summary>
    public SolarPanelDetailedDTO? SolarPanel { get; set; }

    /// <summary>
    /// Dados da Turbina Eólica
    /// </summary>
    public WindTurbineDetailedDTO? WindTurbine { get; set; }
}
