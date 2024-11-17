using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public int IdWindTurbineType { get; set; }

    /// <summary>
    /// Voltagem da Turbina Eólica
    /// </summary>
    [Column("DS_VOLTAGE")]
    public string DsVoltage { get; set; }

    /// <summary>
    /// Modelo da Turbina Eólica
    /// </summary>
    [Column("DS_MODEL")]
    public string DsModel { get; set; }

    /// <summary>
    /// Fabricante da Turbina Eólica
    /// </summary>
    [Column("DS_MANUFACTURER")]
    public string DsManufacturer { get; set; }

    /// <summary>
    /// Tipo de Gerador da Turbina Eólica
    /// </summary>
    [Column("DS_GENERATOR_TYPE")]
    public string DsGeneratorType { get; set; }

    /// <summary>
    /// Garantia da Turbina Eólica em Anos
    /// </summary>
    [Column("DS_WARRANTY_YEARS")]
    public int DsWarrantyYears { get; set; }

}
