namespace APITechZap.Models.DTOs.SolarPanelDTOs;

/// <summary>
/// DTO para os tipos de painel solar
/// </summary>
public class SolarPanelTypeDTO
{
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
