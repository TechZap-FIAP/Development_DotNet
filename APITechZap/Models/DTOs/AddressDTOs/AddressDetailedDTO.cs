namespace APITechZap.Models.DTOs.AddressDTOs;

/// <summary>
/// Address Detailed DTO
/// </summary>
public class AddressDetailedDTO
{
    /// <summary>
    /// Id of Address
    /// </summary>
    public int IdAddress { get; set; }
    /// <summary>
    /// Street of Address
    /// </summary>
    public string? DsStreet { get; set; }

    /// <summary>
    /// Number of Address
    /// </summary>
    public int? DsNumber { get; set; }

    /// <summary>
    /// Complement of Address
    /// </summary>
    public string? DsComplement { get; set; }

    /// <summary>
    /// Neighborhood of Address
    /// </summary>
    public string? DsNeighborhood { get; set; }

    /// <summary>
    /// City of Address
    /// </summary>
    public string? DsCity { get; set; }

    /// <summary>
    /// State of Address
    /// </summary>
    public string? DsState { get; set; }

    /// <summary>
    /// ZipCode of Address
    /// </summary>
    public string? DsZipCode { get; set; }
}
