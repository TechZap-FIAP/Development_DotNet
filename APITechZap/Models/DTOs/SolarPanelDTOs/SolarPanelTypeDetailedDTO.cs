namespace APITechZap.Models.DTOs.SolarPanelDTOs;

/// <summary>
/// DTO de Tipo de Painel Solar Detalhado
/// </summary>
public class SolarPanelTypeDetailedDTO
{
    /// <summary>
    /// Id do Tipo de Painel Solar
    /// </summary>
    public int IdSolarPanelType { get; set; }

    /// <summary>
    /// Voltagem do Painel Solar
    /// </summary>
    public string? DsVoltage { get; set; }

    /// <summary>
    /// Modelo do Painel Solar
    /// </summary>
    public string? DsModel { get; set; }

    /// <summary>
    /// Fabricante do Painel Solar
    /// </summary>
    public string? DsManufacturer { get; set; }

    /// <summary>
    /// Tipo de Célula do Painel Solar
    /// </summary>
    public string? DsCellType { get; set; }

    /// <summary>
    /// Custo por Watts do Painel Solar
    /// </summary>
    public double? DsCostPerWatts { get; set; }

    /// <summary>
    /// Garantia do Produto do Painel Solar
    /// </summary>
    public int? DsProductWarranty { get; set; }
}
