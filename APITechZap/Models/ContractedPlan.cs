using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechZap.Models;

/// <summary>
/// Tabela de Planos Contratados
/// </summary>
[Table("T_TZ_CONTRACTED_PLAN")]
public class ContractedPlan
{
    /// <summary>
    /// Identificador do Plano Contratado
    /// </summary>
    [Key]
    [Column("ID_CONTRACTED_PLAN")]
    public int IdContractedPlan { get; set; }

    // Datas de Criação, Atualização e Exclusão do Plano Contratado
    /// <summary>
    /// Data de Criação do Plano Contratado
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Data de Atualização do Plano Contratado
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Data de Exclusão do Plano Contratado
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime? DeletedAt { get; set; }

    // Relacionamentos com outras tabelas

    /// <summary>
    /// Identificador do Usuário
    /// </summary>
    [ForeignKey("ID_USER")]
    public User? user { get; set; }

    /// <summary>
    /// Identificador do Painel Solar
    /// </summary>
    [ForeignKey("ID_SOLAR_PANEL")]
    public SolarPanel? solarPanel { get; set; }

    /// <summary>
    /// Identificador da Turbina Eólica
    /// </summary>
    [ForeignKey("ID_WIND_TURBINE")]
    public WindTurbine? windTurbine { get; set; }
}
