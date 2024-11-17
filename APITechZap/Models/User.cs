using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APITechZap.Models;

/// <summary>
/// Tabela de Usuários
/// </summary>
[Table("T_TZ_USER")]
public class User
{
    /// <summary>
    /// Identificador do Usuário
    /// </summary>
    [Key]
    [JsonIgnore]
    [Column("ID_USER")]
    public int IdUser { get; set; }

    /// <summary>
    /// Identificador do Usuário no Firebase
    /// </summary>
    [JsonIgnore]
    [Column("DS_UID_FB")]
    public string? DsUidFirebase { get; set; }

    /// <summary>
    /// Nome do Usuário
    /// </summary>
    [Column("DS_NAME")]
    public required string DsName { get; set; }

    /// <summary>
    /// Sobrenome do Usuário
    /// </summary>
    [Column("DS_SURNAME")]
    public required string DsSurname { get; set; }

    /// <summary>
    /// E-mail do Usuário
    /// </summary>
    [Column("DS_EMAIL")]
    public required string DsEmail { get; set; }

    /// <summary>
    /// Senha do Usuário
    /// </summary>
    [Column("DS_PASSWORD")]
    public required string DsPassword { get; set; }

    // Datas de Criação, Atualização e Exclusão

    /// <summary>
    /// Data de Criação do Usuário
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    [Column("DT_CREATED_AT")]
    [JsonIgnore]
    public DateTime DtCreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Data de Atualização do Usuário
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    [Column("DT_UPDATED_AT")]
    [JsonIgnore]
    public DateTime? DtUpdatedAt { get; set; }

    /// <summary>
    /// Data de Exclusão do Usuário
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}", ApplyFormatInEditMode = true)]
    [Column("DT_DELETED_AT")]
    [JsonIgnore]
    public DateTime? DtDeletedAt { get; set; }

    // Relacionamento com a Tabela de Dados Adicionais

    /// <summary>
    /// Dados Adicionais do Usuário
    /// </summary>
    [ForeignKey("ID_USER_ADDITIONAL_DATA")]
    public UserAdditionalData? UserAdditionalData { get; set; }
}