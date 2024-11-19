using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int IdContractedPlan { get; set; }

    // Datas de Criação, Atualização e Exclusão do Plano Contratado
    /// <summary>
    /// Data de Criação do Plano Contratado
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime DtCreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Data de Atualização do Plano Contratado
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime? DtUpdatedAt { get; set; }

    /// <summary>
    /// Data de Exclusão do Plano Contratado
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime? DtDeletedAt { get; set; }


    // Relacionamento com a entidade User
    /// <summary>
    /// Identificador do Usuário associado
    /// </summary>
    [Column("ID_USER")]
    [JsonIgnore]
    public int? IdUser { get; set; }

    /// <summary>
    /// Dados do Usuário
    /// </summary>
    public User? User { get; set; }

    // Relacionamento com a entidade SolarPanel
    /// <summary>
    /// Identificador do Painel Solar associado
    /// </summary>
    [Column("ID_SOLAR_PANEL")]
    [JsonIgnore]
    public int? IdSolarPanel { get; set; }

    /// <summary>
    /// Dados do Painel Solar
    /// </summary>
    public SolarPanel? SolarPanel { get; set; }

    // Relacionamento com a entidade WindTurbine
    /// <summary>
    /// Identificador da Turbina Eólica associada
    /// </summary>
    [Column("ID_WIND_TURBINE")]
    [JsonIgnore]
    public int? IdWindTurbine { get; set; }

    /// <summary>
    /// Dados da Turbina Eólica
    /// </summary>
    public WindTurbine? WindTurbine { get; set; }
}
