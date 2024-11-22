namespace APITechZap.Services.ArtificialIntelligence;

/// <summary>
/// Serviço de IA
/// </summary>
public interface IAiService
{
    /// <summary>
    /// Metodo para auxiliar o usuário com IA
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns></returns>
    Task<string> TriggerOpenAI(string prompt);
}
