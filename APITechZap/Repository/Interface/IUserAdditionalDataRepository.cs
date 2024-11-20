using APITechZap.Models;
using APITechZap.Models.DTOs.UserAdditionalDataDTOs;

namespace APITechZap.Repository.Interface;

/// <summary>
/// Interface de Repositório de Dados Adicionais do Usuário
/// </summary>
public interface IUserAdditionalDataRepository
{
    /// <summary>
    /// Adiciona os Dados Adicionais no Usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<string> AddUserAdditionalDataAsync(int userId, UserAdditionalDataDTO request);

    /// <summary>
    /// Atualiza os Dados Adicionais do Usuário
    /// </summary>
    /// <param name="request"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<string> UpdateUserAdditionalDataAsync(int userId, UserAdditionalDataUpdateDTO request);

    /// <summary>
    /// Busca os Dados Adicionais do Usuário pelo ID do Usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<UserAdditionalData> GetUserAdditionalDataByUserIdAsync(int userId);
}
