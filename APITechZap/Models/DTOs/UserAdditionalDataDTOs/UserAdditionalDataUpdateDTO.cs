namespace APITechZap.Models.DTOs.UserAdditionalDataDTOs;

/// <summary>
/// UserAdditionalDataUpdateDTO class is used to update the additional data of the user.
/// </summary>
public class UserAdditionalDataUpdateDTO
{
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
