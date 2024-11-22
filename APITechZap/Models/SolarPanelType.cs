using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APITechZap.Models;

/// <summary>
/// Classe que representa o tipo de painel solar
/// </summary>
[Table("T_TZ_SOLAR_PANEL_TYPE")]
public class SolarPanelType
{
    /// <summary>
    /// Identificador do Tipo de Painel Solar
    /// </summary>
    [Key]
    [Column("ID_SOLAR_PANEL_TYPE")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int IdSolarPanelType { get; set; }

    /// <summary>
    /// Voltagem do Painel Solar
    /// </summary>
    [Column("DS_VOLTAGE")]
    public string? DsVoltage { get; set; }

    /// <summary>
    /// Modelo do Painel Solar
    /// </summary>
    [Column("DS_MODEL")]
    public string? DsModel { get; set; }

    /// <summary>
    /// Fabricante do Painel Solar
    /// </summary>
    [Column("DS_MANUFACTURER")]
    public string? DsManufacturer { get; set; }

    /// <summary>
    /// Tipo de Célula do Painel Solar
    /// </summary>
    [Column("DS_CELL_TYPE")]
    public string? DsCellType { get; set; }

    /// <summary>
    /// Custo por Watts do Painel Solar
    /// </summary>
    [Column("DS_COST_PER_WATTS")]
    public double? DsCostPerWatts { get; set; }

    /// <summary>
    /// Garantia do Produto do Painel Solar
    /// </summary>
    [Column("DS_PRODUCT_WARRANTY")]
    public int? DsProductWarranty { get; set; }

    /// <summary>
    /// Identificador do Tipo de Painel Solar
    /// </summary>
    [ForeignKey("SolarPanel")]
    [Column("ID_SOLAR_PANEL")]
    [JsonIgnore]
    public int IdSolarPanel { get; set; }

    /// <summary>
    /// Painel Solar
    /// </summary>
    public SolarPanel? SolarPanel { get; set; }
}
