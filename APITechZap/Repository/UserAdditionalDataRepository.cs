using APITechZap.Data;
using APITechZap.Models;
using APITechZap.Models.DTOs.UserAdditionalDataDTOs;
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
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<string> AddUserAdditionalDataAsync(int userId, UserAdditionalDataDTO request)
    {
        if (request == null)
        {
            throw new ArgumentException("Dados adicionais são obrigatórios.");
        }

        // Encontra o usuário pelo ID
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.IdUser == userId && u.DtDeletedAt == null) ?? throw new Exception("Usuário não encontrado."); ;

        bool cpfExists = await _dbContext.UserAdditionalDatas.AnyAsync(u => u.DsCPF == request.DsCPF);

        if (cpfExists)
        {
            return "O CPF informado já existe.";
        }

        // Cria os dados adicionais
        var userAdditionalData = new UserAdditionalData
        {
            DsCPF = request.DsCPF,
            DsPhone = request.DsPhone,
            DtBirthDate = request.DtBirthDate,
            IdUser = user.IdUser, // Associa o usuário aos dados adicionais
        };

        try
        {
            await _dbContext.UserAdditionalDatas.AddAsync(userAdditionalData);
            await _dbContext.SaveChangesAsync();

            return "Dados Adicionais do Usuário foram adicionados com sucesso!";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// Método para atualizar os Dados Adicionais do Usuário
    /// </summary>
    /// <param name="request"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<string> UpdateUserAdditionalDataAsync(int userId, UserAdditionalDataUpdateDTO request)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserAdditionalData)
            .FirstOrDefaultAsync(u => u.IdUser == userId && u.DtDeletedAt == null) 
            ?? throw new Exception("Usuário não encontrado.");

        var userAdditionalData = await _dbContext.UserAdditionalDatas
            .FirstOrDefaultAsync(u => u.IdUser == userId && u.DtDeletedAt == null) 
            ?? throw new Exception("Dados Adicionais não encontrados!");

        bool cpfExists = await _dbContext.UserAdditionalDatas
            .AnyAsync(u => u.DsCPF == request.DsCPF);

        if (cpfExists)
        {
            return "O CPF informado já existe.";
        }
        else if (request.DsCPF != null)
        {
            userAdditionalData.DsCPF = request.DsCPF;
        }

        if (request.DsPhone != null)
        {
            userAdditionalData.DsPhone = request.DsPhone;
        }

        if (request.DtBirthDate != null)
        {
            userAdditionalData.DtBirthDate = request.DtBirthDate;
        }

        userAdditionalData.DtUpdatedAt = DateTime.Now;

        try
        {
            await _dbContext.SaveChangesAsync();

            return "Dados Adicionais do Usuário Atualizado com Sucesso!";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// Método para buscar os Dados Adicionais do Usuário pelo Id do Usuário
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<UserAdditionalData> GetUserAdditionalDataByUserIdAsync(int userId)
    {
        var userAdditionalData = await _dbContext.UserAdditionalDatas.FirstOrDefaultAsync(uda => uda.IdUser == userId && uda.DtDeletedAt == null) ?? throw new Exception("Dados Adicionais não encontrados!");

        return userAdditionalData;
    }
}
