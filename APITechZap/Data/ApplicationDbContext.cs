using APITechZap.Models;
using Microsoft.EntityFrameworkCore;

namespace APITechZap.Data;

/// <summary>
/// Classe ApplicationDbContext que herda de DbContext e é responsável por mapear as tabelas do banco de dados
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Construtor da Classe ApplicationDbContext que herda de DbContext e recebe um objeto do tipo DbContextOptions"ApplicationDbContext" como parâmetro para a conexão com o banco de dados
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Tabela de Usuários
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Tabela de Dados Adicionais do Usuário
    /// </summary>
    public DbSet<UserAdditionalData> UserAdditionalDatas { get; set; }

    /// <summary>
    /// Tabela de Endereços
    /// </summary>
    public DbSet<Address> Addresses { get; set; }

    /// <summary>
    /// Tabela de Contratos
    /// </summary>
    public DbSet<ContractedPlan> ContractedPlans { get; set; }

    /// <summary>
    /// Tabela de Paineis Solares
    /// </summary>
    public DbSet<SolarPanel> SolarPanels { get; set; }

    /// <summary>
    /// Tabela de Tipos de Paineis Solares
    /// </summary>
    public DbSet<SolarPanelType> SolarPanelTypes { get; set; }

    /// <summary>
    /// Tabela de Turbinas Eólicas
    /// </summary>
    public DbSet<WindTurbine> WindTurbines { get; set; }

    /// <summary>
    /// Tabela de Tipos de Turbinas Eólicas
    /// </summary>
    public DbSet<WindTurbineType> WindTurbineTypes { get; set; }

}
