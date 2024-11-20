using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APITechZap.Models;

/// <summary>
/// Tabela de Endereços
/// </summary>
[Table("T_TZ_ADDRESS")]
public class Address
{
    /// <summary>
    /// Identificador do Endereço
    /// </summary>
    [Key]
    [Column("ID_ADDRESS")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int IdAddress { get; set; }

    /// <summary>
    /// Rua do Endereço
    /// </summary>
    [Column("DS_STREET")]
    public string? DsStreet { get; set; }

    /// <summary>
    /// Numero do Endereço
    /// </summary>
    [Column("DS_NUMBER")]
    public int? DsNumber { get; set; }

    /// <summary>
    /// Complemento do Endereço
    /// </summary>
    [Column("DS_COMPLEMENT")]
    public string? DsComplement { get; set; }

    /// <summary>
    /// Bairro do Endereço
    /// </summary>
    [Column("DS_NEIGHBORHOOD")]
    public string? DsNeighborhood { get; set; }

    /// <summary>
    /// Cidade do Endereço
    /// </summary>
    [Column("DS_CITY")]
    public string? DsCity { get; set; }

    /// <summary>
    /// Estado do Endereço
    /// </summary>
    [Column("DS_STATE")]
    public string? DsState { get; set; }

    /// <summary>
    /// CEP do Endereço
    /// </summary>
    [Column("DS_ZIPCODE")]
    public string? DsZipCode { get; set; }

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