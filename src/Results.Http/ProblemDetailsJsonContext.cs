using System.Text.Json.Serialization;

namespace Tolitech.Results.Http;

/// <summary>
/// Represents a partial class for configuring JSON serialization for the <see cref="ProblemDetailsResponse"/> type.
/// </summary>
[JsonSerializable(typeof(ProblemDetailsResponse))]
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
public partial class ProblemDetailsJsonContext : JsonSerializerContext;