using APITechZap.Models.DTOs.AddressDTOs;
using APITechZap.Models.DTOs.ContractedPlanDTOs;
using APITechZap.Models.DTOs.UserAdditionalDataDTOs;

namespace APITechZap.Models.DTOs.UserDTOs;

/// <summary>
/// User Detailed DTO
/// </summary>
public class UserDetailedDTO
{
    /// <summary>
    /// User Id
    /// </summary>
    public int IdUser { get; set; }

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
    /// Dados Adicionais do Usuário
    /// </summary>
    public UserAdditionalDataDetailedDTO? UserAdditionalDataDTO { get; set; }

    /// <summary>
    /// Endereço do Usuário
    /// </summary>
    public AddressDetailedDTO? AddressDTO { get; set; }

}
