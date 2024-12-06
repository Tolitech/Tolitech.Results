using System.Net.Http.Json;

namespace Tolitech.Results.Http;

/// <summary>
/// Extension methods for handling HTTP responses and populating a Result object.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Reads the content of the HttpResponseMessage asynchronously and populates the provided Result object.
    /// </summary>
    /// <param name="result">The Result object to populate.</param>
    /// <param name="response">The HttpResponseMessage containing the response.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either the result or response is null.</exception>
    public static async Task ReadProblemDetailsAsync(this Result result, HttpResponseMessage response)
    {
        ArgumentNullException.ThrowIfNull(result);
        ArgumentNullException.ThrowIfNull(response);

        if (response.IsSuccessStatusCode)
        {
            return;
        }

        try
        {
            ProblemDetailsResponse? problemDetailsResponse = await response.Content
                .ReadFromJsonAsync(ProblemDetailsJsonContext.Default.ProblemDetailsResponse)
                .ConfigureAwait(false);

            result.WithType(problemDetailsResponse!.Type)
                .WithTitle(problemDetailsResponse.Title)
                .WithDetail(problemDetailsResponse.Detail)
                .WithStatusCode((StatusCode)problemDetailsResponse.Status);

            if (problemDetailsResponse.Errors != null)
            {
                foreach (ProblemDetailsResponse.MessageResponse error in problemDetailsResponse.Errors)
                {
                    result
                        .WithContext(error.ContextName!)
                        .AddError(error.Key, error.Message!);
                }
            }
        }
        catch (Exception ex)
        {
            result.WithTitle("Conversion Failure")
                .WithDetail("Unable to convert the return of the HttpResponseMessage object into a ProblemDetailsResponse.")
                .AddError(ex.Message, StatusCode.InternalServerError, ex);
        }
    }
}