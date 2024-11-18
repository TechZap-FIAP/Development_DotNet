using System.Text.Json.Serialization;

namespace ApiGreenway.Models;

/// <summary>
/// AuthFirebase Model
/// </summary>
public class AuthFirebase
{
    /// <summary>
    /// Kind of AuthFirebase
    /// </summary>
    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    /// <summary>
    /// LocalId of AuthFirebase
    /// </summary>
    [JsonPropertyName("localId")]
    public string? LocalId { get; set; }

    /// <summary>
    /// Email of AuthFirebase
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// DisplayName of AuthFirebase
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    /// <summary>
    /// IdToken of AuthFirebase
    /// </summary>
    [JsonPropertyName("idToken")]
    public string? IdToken { get; set; }

    /// <summary>
    /// Registered of AuthFirebase
    /// </summary>
    [JsonPropertyName("registered")]
    public bool Registered { get; set; }

    /// <summary>
    /// RefreshToken of AuthFirebase
    /// </summary>
    [JsonPropertyName("refreshToken")]
    public string? RefreshToken { get; set; }

    /// <summary>
    /// ExpiresIn of AuthFirebase
    /// </summary>
    [JsonPropertyName("expiresIn")]
    public long ExpiresIn { get; set; }
}
