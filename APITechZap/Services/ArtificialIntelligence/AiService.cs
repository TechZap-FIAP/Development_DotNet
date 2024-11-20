
using System.Text.Json;
using System.Text;

namespace APITechZap.Services.ArtificialIntelligence;

/// <summary>
/// Serviço de IA
/// </summary>
public class AiService : IAiService
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Busca o endpoint da IA
    /// </summary>
    /// <param name="httpClient"></param>
    public AiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Metodo para auxiliar o usuário com a IA
    /// </summary>
    /// <param name="userQuery"></param>
    /// <returns></returns>
    public async Task<string> GetApplicationHelpAsync(string userQuery)
    {
        // Restrições para garantir que a IA só responde sobre a aplicação.
        var prompt = $"Você é um assistente projetado exclusivamente para ajudar os usuários da aplicação. " +
                     $"Só responda perguntas diretamente relacionadas à aplicação. Outras informações ou dúvidas externas são inválidas. " +
                     $"Não informar documento de usuário ou da empresa. " +
                     $"Pergunta: {userQuery}";

        var requestBody = new
        {
            model = "gpt-4o",
            prompt = prompt,
            max_tokens = 150,
            temperature = 0.5
        };

        var requestContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync("completions", requestContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonDocument.Parse(responseContent);
            var completion = jsonResponse.RootElement.GetProperty("choices")[0].GetProperty("text").GetString()?.Trim() ?? "Sem resposta.";
            return completion ?? string.Empty;
        }
        catch (Exception ex)
        {
            // Tratamento de erros
            return $"Ocorreu um erro ao se comunicar com o OpenAI: {ex.Message}";
        }
    }
}
