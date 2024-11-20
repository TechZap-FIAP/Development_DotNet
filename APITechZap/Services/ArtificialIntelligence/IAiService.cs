namespace APITechZap.Services.ArtificialIntelligence;

/// <summary>
/// Serviço de IA
/// </summary>
public interface IAiService
{
    /// <summary>
    /// Metodo para auxiliar o usuário com IA
    /// </summary>
    /// <param name="userQuery"></param>
    /// <returns></returns>
    Task<string> GetApplicationHelpAsync(string userQuery);
}
