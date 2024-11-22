namespace APITechZap.Models.DTOs.ContractedPlanDTOs;

/// <summary>
/// DTO para os planos contratados
/// </summary>
public class ContractedPlanDTO
{
    /// <summary>
    /// Identificador da Turbina eólica
    /// </summary>
    public int? IdWindTurbine { get; set; }

    /// <summary>
    /// Identificador do Painel solar
    /// </summary>
    public int? IdSolarPanel { get; set; }
}
