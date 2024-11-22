namespace APITechZap.Models.DTOs.UserAdditionalDataDTOs;

/// <summary>
/// UserAdditionalDataDetailed class is used to store the additional data of the user.
/// </summary>
public class UserAdditionalDataDetailedDTO
{
    /// <summary>
    /// Gets or sets the user's Id.
    /// </summary>
    public int IdUserAdditionalData { get; set; }

    /// <summary>
    /// Gets or sets the user's CPF.
    /// </summary>
    public string? DsCPF { get; set; }

    /// <summary>
    /// Gets or sets the user's Phone.
    /// </summary>
    public string? DsPhone { get; set; }

    /// <summary>
    /// Gets or sets the user's BirthDate.
    /// </summary>
    public DateTime? DtBirthDate { get; set; }
}
