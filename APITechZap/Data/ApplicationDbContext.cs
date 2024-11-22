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

    /// <summary>
    /// Relacionamento entre as tabelas User, UserAdditionalData e Address
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relacionamento 1:1 entre User e UserAdditionalData
        modelBuilder.Entity<User>()
            .HasOne(u => u.UserAdditionalData)
            .WithOne(uda => uda.User)
            .HasForeignKey<UserAdditionalData>(uda => uda.IdUser);

        // Relacionamento 1:1 entre User e Address
        modelBuilder.Entity<User>()
            .HasOne(uda => uda.Address)
            .WithOne(a => a.User)
            .HasForeignKey<Address>(a => a.IdUser);

        // Relacionamento 1:N entre User e ContractedPlan
        modelBuilder.Entity<User>()
            .HasMany(u => u.ContractedPlans)
            .WithOne(cp => cp.User)
            .HasForeignKey(cp => cp.IdUser);

        // Relacionamento 1:1 entre ContractedPlan e SolarPanel
        modelBuilder.Entity<ContractedPlan>()
            .HasOne(cp => cp.SolarPanel)
            .WithOne()
            .HasForeignKey<ContractedPlan>(cp => cp.IdSolarPanel);

        // Relacionamento 1:1 entre ContractedPlan e WindTurbine
        modelBuilder.Entity<ContractedPlan>()
            .HasOne(cp => cp.WindTurbine)
            .WithOne()
            .HasForeignKey<ContractedPlan>(cp => cp.IdWindTurbine);

        // Relacionamento 1:1 entre SolarPanel e SolarPanelType
        modelBuilder.Entity<SolarPanel>()
            .HasOne(sp => sp.SolarPanelType)
            .WithOne(spType => spType.SolarPanel)
            .HasForeignKey<SolarPanelType>(spType => spType.IdSolarPanel);

        // Relacionamento 1:1 entre WindTurbine e WindTurbineType
        modelBuilder.Entity<WindTurbine>()
            .HasOne(wt => wt.WindTurbineType)
            .WithOne(wtType => wtType.WindTurbine)
            .HasForeignKey<WindTurbineType>(wtType => wtType.IdWindTurbine);

        base.OnModelCreating(modelBuilder);
    }
}
