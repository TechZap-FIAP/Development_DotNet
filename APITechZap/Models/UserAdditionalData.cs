using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechZap.Models;

/// <summary>
/// Tabela de Dados Adicionais do Usuário
/// </summary>
[Table("T_TZ_ADDITIONAL_DATA")]
public class UserAdditionalData
{
    /// <summary>
    /// Identificador dos Dados Adicionais
    /// </summary>
    [Key]
    [Column("ID_ADDITIONAL_DATA")]
    public int IdAdditionalData { get; set; }

    /// <summary>
    /// Data de Nascimento do Usuário
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Column("DT_BIRTH_DATE")]
    public DateTime DtBirthDate { get; set; }

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
    /// Identificador do Endereço
    /// </summary>
    [ForeignKey("ID_ADDRESS")]
    public Address? Address { get; set; }
}