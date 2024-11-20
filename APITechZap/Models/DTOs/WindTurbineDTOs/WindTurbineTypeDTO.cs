namespace APITechZap.Models.DTOs.WindTurbineDTOs;

/// <summary>
/// DTO de Tipo de Turbina Eólica
/// </summary>
public class WindTurbineTypeDTO
{
    /// <summary>
    /// Voltagem da Turbina Eólica
    /// </summary>
    public string? DsVoltage { get; set; }

    /// <summary>
    /// Modelo da Turbina Eólica
    /// </summary>
    public string? DsModel { get; set; }

    /// <summary>
    /// Fabricante da Turbina Eólica
    /// </summary>
    public string? DsManufacturer { get; set; }

    /// <summary>
    /// Tipo de Gerador da Turbina Eólica
    /// </summary>
    public string? DsGeneratorType { get; set; }

    /// <summary>
    /// Garantia da Turbina Eólica em Anos
    /// </summary>
    public int? DsWarrantyYears { get; set; }
}
