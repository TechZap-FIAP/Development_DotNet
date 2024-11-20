namespace APITechZap.Models.DTOs.UserDTOs;

/// <summary>
/// DTO para registro de Usuário
/// </summary>
public class UserRegisterDTO
{
    /// <summary>
    /// Nome do Usuário
    /// </summary>
    public required string DsName { get; set; }

    /// <summary>
    /// Sobrenome do Usuário
    /// </summary>
    public required string DsSurname { get; set; }

    /// <summary>
    /// E-mail do Usuário
    /// </summary>
    public required string DsEmail { get; set; }

    /// <summary>
    /// Senha do Usuário
    /// </summary>
    public required string DsPassword { get; set; }
}
