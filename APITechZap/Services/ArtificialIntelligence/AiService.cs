
using System.Text.Json;
using System.Text;
using APITechZap.Models.DTOs.OpenAiDTOs;
using System.Net.Http.Headers;

namespace APITechZap.Services.ArtificialIntelligence;

/// <summary>
/// Serviço de IA
/// </summary>
public class AiService : IAiService
{
    /// <summary>
    /// Configuração
    /// </summary>
    public readonly IConfiguration _configuration;

    /// <summary>
    /// Construtor da Classe AiService
    /// </summary>
    /// <param name="configuration"></param>
    public AiService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Método para acionar o OpenAI
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns></returns>
    /// <exception cref="System.Exception"></exception>
    public async Task<string> TriggerOpenAI(string prompt)
    {
        var apiKey = _configuration.GetValue<string>("AiService:ApiKey");
        var baseUrl = _configuration.GetValue<string>("AiService:Uri");

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var request = new OpenAIRequestDto
        {
            Model = "gpt-3.5-turbo",
            Messages = new List<OpenAIMessageRequestDto>{
                    new OpenAIMessageRequestDto
                    {
                        Role = "user",
                        Content = prompt
                    }
                },
            MaxTokens = 100
        };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(baseUrl, content);
        var resjson = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = JsonSerializer.Deserialize<OpenAIErrorResponseDto>(resjson);
            throw new Exception(errorResponse.Error.Message);
        }
        var data = JsonSerializer.Deserialize<OpenAIResponseDto>(resjson);
        var responseText = data.choices[0].message.content;

        return responseText;
    }
}
