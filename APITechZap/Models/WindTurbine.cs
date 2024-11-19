using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APITechZap.Models;

/// <summary>
/// Tabela de Turbinas Eólicas
/// </summary>
[Table("T_TZ_WIND_TURBINE")]
public class WindTurbine
{
    /// <summary>
    /// Identificador da Turbina Eólica
    /// </summary>
    [Key]
    [Column("ID_WIND_TURBINE")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int IdWindTurbine { get; set; }

    /// <summary>
    /// Tamanho da Turbina Eólica
    /// </summary>
    [Column("DS_SIZE")]
    public double? DsSize { get; set; }

    /// <summary>
    /// Material da Turbina Eólica
    /// </summary>
    [Column("DS_MATERIAL")]
    public string? DsMaterial { get; set; }

    /// <summary>
    /// Preço da Turbina Eólica
    /// </summary>
    [Column("DS_PRICE")]
    public double? DsPrice { get; set; }

    /// <summary>
    /// Tipo da Turbina Eólica
    /// </summary>
    [ForeignKey("ID_WIND_TURBINE_TYPE")]
    public WindTurbineType? WindTurbineType { get; set; }
}
