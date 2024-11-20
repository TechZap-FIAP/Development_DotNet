using System.ComponentModel.DataAnnotations.Schema;

namespace APITechZap.Models.DTOs.UserDTOs;

/// <summary>
/// UserLoginDTO class is used to store the login data of the user.
/// </summary>
public class UserLoginDTO
{
    /// <summary>
    /// Gets or sets the user's Email.
    /// </summary>
    public required string DsEmail { get; set; }

    /// <summary>
    /// Gets or sets the user's Password.
    /// </summary>
    public required string DsPassword { get; set; }
}
