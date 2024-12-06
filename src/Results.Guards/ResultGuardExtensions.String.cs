namespace Tolitech.Results.Guards;

/// <summary>
/// Provides extension methods for working with <see cref="ResultGuard"/>.
/// </summary>
public static partial class ResultGuardExtensions
{
    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified string value is null.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfNull(this ResultGuard<string?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null)
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified string value is null or empty.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfNullOrEmpty(this ResultGuard<string?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (string.IsNullOrEmpty(guard.Value))
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfNullOrEmpty;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified string value is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfNullOrWhiteSpace(this ResultGuard<string?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (string.IsNullOrWhiteSpace(guard.Value))
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfNullOrWhiteSpace;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified string value is not null.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfNotNull(this ResultGuard<string?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null)
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfNotNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified string value is not null or empty.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfNotNullOrNotEmpty(this ResultGuard<string?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!string.IsNullOrEmpty(guard.Value))
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfNotNullOrNotEmpty;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified string value is equal to the target string.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target string for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfEqualTo(this ResultGuard<string?> guard, string? target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value == target)
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified string value is not equal to the target string.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target string for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfNotEqualTo(this ResultGuard<string?> guard, string? target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value != target)
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfNotEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the length of the specified string value is not equal to the specified length.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="length">The target length for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfLengthEqualTo(this ResultGuard<string?> guard, int length, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!string.IsNullOrEmpty(guard.Value) && guard.Value.Length == length)
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfLengthEqualTo;
            message = TransformMessage(guard, message, resourceMessage, length);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the length of the specified string value is not equal to the specified length.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="length">The target length for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfLengthNotEqualTo(this ResultGuard<string?> guard, int length, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!string.IsNullOrEmpty(guard.Value) && guard.Value.Length != length)
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfLengthNotEqualTo;
            message = TransformMessage(guard, message, resourceMessage, length);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the length of the specified string value is greater than the specified length.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="length">The target length for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfLengthGreaterThan(this ResultGuard<string?> guard, int length, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!string.IsNullOrEmpty(guard.Value) && guard.Value.Length > length)
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfLengthGreaterThan;
            message = TransformMessage(guard, message, resourceMessage, length);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the length of the specified string value is greater than or equal to the specified length.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="length">The target length for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfLengthGreaterThanOrEqualTo(this ResultGuard<string?> guard, int length, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!string.IsNullOrEmpty(guard.Value) && guard.Value.Length >= length)
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfLengthGreaterThanOrEqualTo;
            message = TransformMessage(guard, message, resourceMessage, length);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the length of the specified string value is less than the specified length.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="length">The target length for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfLengthLessThan(this ResultGuard<string?> guard, int length, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!string.IsNullOrEmpty(guard.Value) && guard.Value.Length < length)
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfLengthLessThan;
            message = TransformMessage(guard, message, resourceMessage, length);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the length of the specified string value is less than or equal to the specified length.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="length">The target length for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfLengthLessThanOrEqualTo(this ResultGuard<string?> guard, int length, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!string.IsNullOrEmpty(guard.Value) && guard.Value.Length <= length)
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfLengthLessThanOrEqualTo;
            message = TransformMessage(guard, message, resourceMessage, length);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified string value is not a valid email address.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<string?> ErrorIfNotValidEmail(this ResultGuard<string?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (string.IsNullOrWhiteSpace(guard.Value))
        {
            return guard;
        }

        // only is valid if there is only 1 '@' character
        // and it is neither the first nor the last character
        int index = guard.Value.IndexOf('@', StringComparison.CurrentCulture);

        if (!(index > 0 &&
            index != guard.Value.Length - 1 &&
            index == guard.Value.LastIndexOf('@')))
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfNotValidEmail;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Checks if the value contains a specified target string and adds an error message to the <see cref="Result"/> if true.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard{T}"/> instance.</param>
    /// <param name="target">The target string to check for containment.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    /// <remarks>
    /// This method checks if the value, when it is not null, contains the specified target string.
    /// If the condition is true, it adds an error message to the associated <see cref="Result"/> instance.
    /// </remarks>
    public static ResultGuard<string?> ErrorIfContains(this ResultGuard<string?> guard, string? target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && target is not null && guard.Value.Contains(target, StringComparison.Ordinal))
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Checks if the value does not contain a specified target string and adds an error message to the <see cref="Result"/> if true.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard{T}"/> instance.</param>
    /// <param name="target">The target string to check for non-containment.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    /// <remarks>
    /// This method checks if the value, when it is not null, does not contain the specified target string.
    /// If the condition is true, it adds an error message to the associated <see cref="Result"/> instance.
    /// </remarks>
    public static ResultGuard<string?> ErrorIfNotContains(this ResultGuard<string?> guard, string? target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if ((guard.Value is not null && target is null) ||
            (guard.Value is null && target is not null) ||
            (guard.Value is not null && target is not null && !guard.Value.Contains(target, StringComparison.Ordinal)))
        {
            string resourceMessage = message ?? Resources.String.StringResource.ErrorIfNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }
}