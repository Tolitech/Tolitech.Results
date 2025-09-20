namespace Tolitech.Results.Http;

/// <summary>
/// Represents a response containing problem details, typically used to provide error information in an HTTP response.
/// This class encapsulates details about the problem, including a type, title, detail description, HTTP status code, and associated errors.
/// </summary>
/// <param name="Type">A URI or short identifier that categorizes the type of problem. Typically used for machine processing.</param>
/// <param name="Title">A short, human-readable summary of the problem.</param>
/// <param name="Detail">A detailed description of the problem, which can help provide more context for debugging or resolution.</param>
/// <param name="Status">The HTTP status code that is associated with this problem, typically in the 4xx or 5xx range.</param>
/// <param name="Errors">A collection of error messages related to the problem, if any exist. This is typically used to provide more specific details on what went wrong.</param>
public sealed record ProblemDetailsResponse(
    string Type,
    string Title,
    string Detail,
    int Status,
    IEnumerable<ProblemDetailsResponse.ErrorMessageResponse>? Errors)
{
    /// <summary>
    /// Represents an individual error message related to a problem in the response.
    /// This record stores additional context for each error, such as the context name, a key, and the actual error message.
    /// </summary>
    /// <param name="Key">An optional key associated with the error, which can be used for localization or for programmatically identifying the error.</param>
    /// <param name="Message">The actual error message describing the issue in detail, typically aimed at the end user or developer.</param>
    public sealed record ErrorMessageResponse(
        string? Key,
        string Message);
}