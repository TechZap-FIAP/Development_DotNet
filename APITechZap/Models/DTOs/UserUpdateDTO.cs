namespace APITechZap.Models.DTOs;

/// <summary>
/// DTO para Atualização de Usuário
/// </summary>
public class UserUpdateDTO
{
    /// <summary>
    /// Nome do Usuário
    /// </summary>
    public string? DsName { get; set; }

    /// <summary>
    /// Sobrenome do Usuário
    /// </summary>
    public string? DsSurname { get; set; }

    /// <summary>
    /// E-mail do Usuário
    /// </summary>
    public string? DsEmail { get; set; }

    /// <summary>
    /// Senha do Usuário
    /// </summary>
    public string? DsPassword { get; set; }

    /// <summary>
    /// Dados Adicionais do Usuário
    /// </summary>
    public UserAdditionalData? UserAdditionalData { get; set; }
}
