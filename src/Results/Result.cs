using Tolitech.Results.Resources;

namespace Tolitech.Results;

/// <summary>
/// Represents the result of an operation with optional metadata and messages.
/// </summary>
public class Result : IResult
{
    /// <summary>
    /// Represents a list of message results associated with the result.
    /// </summary>
    private List<ErrorMessage>? _errorMessages;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with the specified success status and status code.
    /// </summary>
    /// <param name="isSuccess">A value indicating whether the result is successful.</param>
    /// <param name="statusCode">The status code associated with the result.</param>
    protected internal Result(bool isSuccess, StatusCode statusCode)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
    }

    /// <summary>
    /// Gets or sets the title metadata associated with the result.
    /// </summary>
    public string Title { get; protected set; } = default!;

    /// <summary>
    /// Gets or sets the detail metadata associated with the result.
    /// </summary>
    public string Detail { get; protected set; } = default!;

    /// <summary>
    /// Gets the type metadata associated with the result.
    /// </summary>
    public string? Type { get; private set; }

    /// <summary>
    /// Gets or sets the status code associated with the result.
    /// </summary>
    public StatusCode StatusCode { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the result indicates success.
    /// </summary>
    public bool IsSuccess { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the result indicates failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets a collection of message results associated with the result.
    /// </summary>
    public IReadOnlyCollection<ErrorMessage> Errors => _errorMessages ?? [];

    /// <summary>
    /// Represents a successful result.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating success.</returns>
    public static IResult OK()
    {
        return new Result(true, StatusCode.OK);
    }

    /// <summary>
    /// Represents a result indicating successful creation.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating success.</returns>
    public static IResult Created()
    {
        return new Result(true, StatusCode.Created);
    }

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing, but the processing has not been completed.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating that the request has been accepted for processing.</returns>
    public static IResult Accepted()
    {
        return new Result(true, StatusCode.Accepted);
    }

    /// <summary>
    /// Represents a result indicating no content.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating no content.</returns>
    public static IResult NoContent()
    {
        return new Result(true, StatusCode.NoContent);
    }

    /// <summary>
    /// Represents a result indicating that the requested resource was found.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating that the resource was found.</returns>
    public static IResult Found()
    {
        return new Result(true, StatusCode.Found);
    }

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating no modifications.</returns>
    public static IResult NotModified()
    {
        return new Result(true, StatusCode.NotModified);
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    public static IResult BadRequest()
    {
        return new Result(false, StatusCode.BadRequest) { Title = ErrorMessageResources.BadRequest_Title, Detail = ErrorMessageResources.BadRequest_Detail };
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the bad request.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    public static IResult BadRequest(string detail)
    {
        return new Result(false, StatusCode.BadRequest) { Title = ErrorMessageResources.BadRequest_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="title">A short title describing the bad request.</param>
    /// <param name="detail">A detailed message providing additional context about the bad request.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    public static IResult BadRequest(string title, string detail)
    {
        return new Result(false, StatusCode.BadRequest) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating unauthorized access.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    public static IResult Unauthorized()
    {
        return new Result(false, StatusCode.Unauthorized) { Title = ErrorMessageResources.Unauthorized_Title, Detail = ErrorMessageResources.Unauthorized_Detail };
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with additional details.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for unauthorized access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    public static IResult Unauthorized(string detail)
    {
        return new Result(false, StatusCode.Unauthorized) { Title = ErrorMessageResources.Unauthorized_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with a specific title and additional details.
    /// </summary>
    /// <param name="title">A short title describing the unauthorized access.</param>
    /// <param name="detail">A detailed message providing additional context about the unauthorized access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    public static IResult Unauthorized(string title, string detail)
    {
        return new Result(false, StatusCode.Unauthorized) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    public static IResult Forbidden()
    {
        return new Result(false, StatusCode.Forbidden) { Title = ErrorMessageResources.Forbidden_Title, Detail = ErrorMessageResources.Forbidden_Detail };
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="detail">A detailed message providing the reason for the forbidden access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    public static IResult Forbidden(string detail)
    {
        return new Result(false, StatusCode.Forbidden) { Title = ErrorMessageResources.Forbidden_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="title">A short title describing the forbidden access.</param>
    /// <param name="detail">A detailed message providing additional context about the forbidden access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    public static IResult Forbidden(string title, string detail)
    {
        return new Result(false, StatusCode.Forbidden) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    public static IResult NotFound()
    {
        return new Result(false, StatusCode.NotFound) { Title = ErrorMessageResources.NotFound_Title, Detail = ErrorMessageResources.NotFound_Detail };
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="detail">A detailed message describing why the resource was not found.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    public static IResult NotFound(string detail)
    {
        return new Result(false, StatusCode.NotFound) { Title = ErrorMessageResources.NotFound_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="title">A short title describing the resource not found.</param>
    /// <param name="detail">A detailed message providing additional context about why the resource was not found.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    public static IResult NotFound(string title, string detail)
    {
        return new Result(false, StatusCode.NotFound) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    public static IResult Conflict()
    {
        return new Result(false, StatusCode.Conflict) { Title = ErrorMessageResources.Conflict_Title, Detail = ErrorMessageResources.Conflict_Detail };
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the conflict.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    public static IResult Conflict(string detail)
    {
        return new Result(false, StatusCode.Conflict) { Title = ErrorMessageResources.Conflict_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="title">A short title describing the conflict.</param>
    /// <param name="detail">A detailed message providing additional context about the conflict.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    public static IResult Conflict(string title, string detail)
    {
        return new Result(false, StatusCode.Conflict) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    public static IResult InternalServerError()
    {
        return new Result(false, StatusCode.InternalServerError) { Title = ErrorMessageResources.InternalServerError_Title, Detail = ErrorMessageResources.InternalServerError_Detail };
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="detail">A detailed message describing the internal server error.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    public static IResult InternalServerError(string detail)
    {
        return new Result(false, StatusCode.InternalServerError) { Title = ErrorMessageResources.InternalServerError_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="title">A short title describing the internal server error.</param>
    /// <param name="detail">A detailed message providing additional context about the internal server error.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    public static IResult InternalServerError(string title, string detail)
    {
        return new Result(false, StatusCode.InternalServerError) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Adds an error message to the result with an optional status code and exception.
    /// </summary>
    /// <param name="errorMessage">The error message content.</param>
    /// <param name="statusCode">An optional status code associated with the error.</param>
    public void AddError(string errorMessage, StatusCode statusCode = StatusCode.BadRequest)
    {
        AddError(null, errorMessage, statusCode);
    }

    /// <summary>
    /// Adds an error message to the result with an optional key, status code, and exception.
    /// </summary>
    /// <param name="key">An optional key associated with the error message.</param>
    /// <param name="errorMessage">The error message content.</param>
    /// <param name="statusCode">An optional status code associated with the error.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the provided <paramref name="statusCode"/> represents a success state.
    /// Only error statuses are valid for this method.
    /// </exception>
    public void AddError(string? key, string errorMessage, StatusCode statusCode = StatusCode.BadRequest)
    {
        if (IsStatusCodeSuccess(statusCode))
        {
            throw new InvalidOperationException("Cannot add an error message with a success status code.");
        }

        if (IsSuccess)
        {
            IsSuccess = false;
            StatusCode = statusCode;

            // Set default title and detail.
            SetDefaultErrorMessage(statusCode);
        }

        _errorMessages ??= [];
        _errorMessages.Add(ErrorMessage.Create(key, errorMessage));
    }

    /// <summary>
    /// Adds error messages from the provided result to the internal message collection.
    /// </summary>
    /// <param name="result">An instance of the interface IResult containing messages to be added.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    public IResult AddErrors(IResult result)
    {
        if (result is not null)
        {
            if (IsSuccess && result.IsFailure)
            {
                Title = result.Title;
                Detail = result.Detail;
                Type = result.Type;

                WithStatusCode(result.StatusCode);
            }

            if (result.Errors.Count > 0)
            {
                _errorMessages ??= [];

                foreach (ErrorMessage errorMessage in result.Errors)
                {
                    _errorMessages.AddRange(errorMessage);
                }
            }
        }

        return this;
    }

    /// <summary>
    /// Sets the title metadata for the result.
    /// </summary>
    /// <param name="title">The title to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    public IResult WithTitle(string title)
    {
        Title = title;
        return this;
    }

    /// <summary>
    /// Sets the detail metadata for the result.
    /// </summary>
    /// <param name="detail">The detail to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    public IResult WithDetail(string detail)
    {
        Detail = detail;
        return this;
    }

    /// <summary>
    /// Sets the type metadata for the result.
    /// </summary>
    /// <param name="type">The type to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    public IResult WithType(string? type)
    {
        Type = type;
        return this;
    }

    /// <summary>
    /// Sets the status code for the result.
    /// </summary>
    /// <param name="statusCode">The status code to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when attempting to set a success status code while error messages exist in the <see cref="Errors"/> collection.
    /// This ensures that an object with error messages cannot be marked as successful.
    /// </exception>
    public IResult WithStatusCode(StatusCode statusCode)
    {
        if (!IsSuccess && IsStatusCodeSuccess(statusCode))
        {
            IsSuccess = true;
        }
        else if (IsSuccess && !IsStatusCodeSuccess(statusCode))
        {
            IsSuccess = false;
        }

        if (Errors.Count > 0 && IsStatusCodeSuccess(statusCode))
        {
            throw new InvalidOperationException("Unable to set a success status because there are error messages associated with the object.");
        }

        StatusCode = statusCode;

        return this;
    }

    /// <summary>
    /// Determines whether the provided status code represents a successful response.
    /// </summary>
    /// <param name="statusCode">The status code to check.</param>
    /// <returns>True if the status code represents a successful response; otherwise, false.</returns>
    private static bool IsStatusCodeSuccess(StatusCode statusCode)
    {
        return statusCode is
            StatusCode.OK or
            StatusCode.Created or
            StatusCode.Accepted or
            StatusCode.NoContent or
            StatusCode.Found or
            StatusCode.NotModified;
    }

    /// <summary>
    /// Sets the error message details based on the specified <see cref="StatusCode"/>.
    /// </summary>
    /// <remarks>This method updates the <c>Title</c> and <c>Detail</c> properties with predefined error
    /// messages corresponding to the provided <paramref name="statusCode"/>. If the <paramref name="statusCode"/> does
    /// not match any predefined value, the properties remain unchanged.</remarks>
    /// <param name="statusCode">The HTTP status code that determines the error message. Must be a valid <see cref="StatusCode"/> enumeration
    /// value.</param>
    private void SetDefaultErrorMessage(StatusCode statusCode)
    {
#pragma warning disable IDE0072 // Add missing cases
        (Title, Detail) = statusCode switch
        {
            StatusCode.BadRequest => (ErrorMessageResources.BadRequest_Title, ErrorMessageResources.BadRequest_Detail),
            StatusCode.Unauthorized => (ErrorMessageResources.Unauthorized_Title, ErrorMessageResources.Unauthorized_Detail),
            StatusCode.Forbidden => (ErrorMessageResources.Forbidden_Title, ErrorMessageResources.Forbidden_Detail),
            StatusCode.NotFound => (ErrorMessageResources.NotFound_Title, ErrorMessageResources.NotFound_Detail),
            StatusCode.MethodNotAllowed => (ErrorMessageResources.MethodNotAllowed_Title, ErrorMessageResources.MethodNotAllowed_Detail),
            StatusCode.RequestTimeout => (ErrorMessageResources.RequestTimeout_Title, ErrorMessageResources.RequestTimeout_Detail),
            StatusCode.Conflict => (ErrorMessageResources.Conflict_Title, ErrorMessageResources.Conflict_Detail),
            StatusCode.TooManyRequests => (ErrorMessageResources.TooManyRequests_Title, ErrorMessageResources.TooManyRequests_Detail),
            StatusCode.InternalServerError => (ErrorMessageResources.InternalServerError_Title, ErrorMessageResources.InternalServerError_Detail),
            StatusCode.BadGateway => (ErrorMessageResources.BadGateway_Title, ErrorMessageResources.BadGateway_Detail),
            StatusCode.ServiceUnavailable => (ErrorMessageResources.ServiceUnavailable_Title, ErrorMessageResources.ServiceUnavailable_Detail),
            StatusCode.GatewayTimeout => (ErrorMessageResources.GatewayTimeout_Title, ErrorMessageResources.GatewayTimeout_Detail),
            _ => (Title, Detail),
        };
#pragma warning restore IDE0072 // Add missing cases
    }
}