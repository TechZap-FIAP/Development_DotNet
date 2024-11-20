using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APITechZap.Models;

/// <summary>
/// Tabela de Dados Adicionais do Usuário
/// </summary>
[Table("T_TZ_USER_ADDITIONAL_DATA")]
public class UserAdditionalData
{
    /// <summary>
    /// Identificador dos Dados Adicionais
    /// </summary>
    [Key]
    [Column("ID_USER_ADDITIONAL_DATA")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int IdUserAdditionalData { get; set; }

    /// <summary>
    /// Data de Nascimento do Usuário
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Column("DT_BIRTH_DATE")]
    public DateTime? DtBirthDate { get; set; }

    /// <summary>
    /// CPF do Usuário
    /// </summary>
    [StringLength(14)]
    [Column("DS_CPF")]
    public string? DsCPF { get; set; }

    /// <summary>
    /// Telefone do Usuário
    /// </summary>
    [StringLength(15)]
    [Column("DS_PHONE")]
    public string? DsPhone { get; set; }

    /// <summary>
    /// Data de Criação
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    [Column("DT_CREATED_AT")]
    [JsonIgnore]
    public DateTime DtCreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Data de Atualização
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    [Column("DT_UPDATED_AT")]
    [JsonIgnore]
    public DateTime? DtUpdatedAt { get; set; }

    /// <summary>
    /// Data de Exclusão
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    [Column("DT_DELETED_AT")]
    [JsonIgnore]
    public DateTime? DtDeletedAt { get; set; }

    /// <summary>
    /// Identificador do Usuário
    /// </summary>
    [ForeignKey("User")]
    [Column("ID_USER")]
    [JsonIgnore]
    public int IdUser { get; set; }

    /// <summary>
    /// Usuário Relacionado aos Dados Adicionais
    /// </summary>
    [JsonIgnore]
    public User? User { get; set; }
}