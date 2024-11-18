using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace APITechZap.Repository;

/// <summary>
/// Classe de Repositório de Dados Adicionais do Usuário
/// </summary>
public class UserAdditionalDataRepository : IUserAdditionalDataRepository
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Construtor da Classe UserAdditionalDataRepository
    /// </summary>
    /// <param name="dbContext"></param>
    public UserAdditionalDataRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Método para adicionar os Dados Adicionais do Usuário
    /// </summary>
    /// <param name="userAdditionalData"></param>
    /// <returns></returns>
    public async Task<string> AddUserAdditionalDataAsync(UserAdditionalData userAdditionalData)
    {
        await _dbContext.UserAdditionalDatas.AddAsync(userAdditionalData);
        await _dbContext.SaveChangesAsync();

        return "Dados Adicionais do Usuário Adicionado com Sucesso!";
    }

    /// <summary>
    /// Método para atualizar os Dados Adicionais do Usuário
    /// </summary>
    /// <param name="userAdditionalData"></param>
    /// <returns></returns>
    public async Task<string> UpdateUserAdditionalDataAsync(UserAdditionalData userAdditionalData)
    {
        _dbContext.UserAdditionalDatas.Update(userAdditionalData);
        await _dbContext.SaveChangesAsync();

        return "Dados Adicionais do Usuário Atualizado com Sucesso!";
    }

    /// <summary>
    /// Método para buscar os Dados Adicionais do Usuário pelo Id do Usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<UserAdditionalData> GetUserAdditionalDataByUserIdAsync(int userId)
    {
        var userAdditionalData = await _dbContext.UserAdditionalDatas.FirstOrDefaultAsync(uda => uda.IdUser == userId) ?? throw new Exception("Dados Adicionais não encontrados!");

        return userAdditionalData;
    }
}
