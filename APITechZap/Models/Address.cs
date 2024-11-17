using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

}