using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APITechZap.Models;

/// <summary>
/// Tabela de Tipos de Turbinas Eólicas
/// </summary>
[Table("T_TZ_WIND_TURBINE_TYPE")]
public class WindTurbineType
{
    /// <summary>
    /// Identificador do Tipo de Turbina Eólica
    /// </summary>
    [Key]
    [Column("ID_WIND_TURBINE_TYPE")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int IdWindTurbineType { get; set; }

    /// <summary>
    /// Voltagem da Turbina Eólica
    /// </summary>
    [Column("DS_VOLTAGE")]
    public string? DsVoltage { get; set; }

    /// <summary>
    /// Modelo da Turbina Eólica
    /// </summary>
    [Column("DS_MODEL")]
    public string? DsModel { get; set; }

    /// <summary>
    /// Fabricante da Turbina Eólica
    /// </summary>
    [Column("DS_MANUFACTURER")]
    public string? DsManufacturer { get; set; }

    /// <summary>
    /// Tipo de Gerador da Turbina Eólica
    /// </summary>
    [Column("DS_GENERATOR_TYPE")]
    public string? DsGeneratorType { get; set; }

    /// <summary>
    /// Garantia da Turbina Eólica em Anos
    /// </summary>
    [Column("DS_WARRANTY_YEARS")]
    public int? DsWarrantyYears { get; set; }

    /// <summary>
    /// Identificador doTipo de Turbina Eólica
    /// </summary>
    [ForeignKey("WindTurbine")]
    [Column("ID_WIND_TURBINE")]
    [JsonIgnore]
    public int IdWindTurbine { get; set; }

    /// <summary>
    /// Turbina Eólica
    /// </summary>
    public WindTurbine? WindTurbine { get; set; }
}
