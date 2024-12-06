namespace Tolitech.Results.Guards;

/// <summary>
/// Provides extension methods for working with <see cref="ResultGuard"/>.
/// </summary>
public static partial class ResultGuardExtensions
{
    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is null.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool?> ErrorIfNull(this ResultGuard<bool?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!guard.Value.HasValue)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is not null.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool?> ErrorIfNotNull(this ResultGuard<bool?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value.HasValue)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfNotNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is true.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool?> ErrorIfTrue(this ResultGuard<bool?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value.HasValue && guard.Value == true)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfTrue;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is true.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool> ErrorIfTrue(this ResultGuard<bool> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfTrue;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is false.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool?> ErrorIfFalse(this ResultGuard<bool?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value.HasValue && guard.Value == false)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfFalse;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is false.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool> ErrorIfFalse(this ResultGuard<bool> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!guard.Value)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfFalse;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is false or null.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool?> ErrorIfFalseOrNull(this ResultGuard<bool?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!guard.Value.HasValue || guard.Value == false)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfFalseOrNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is true or null.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool?> ErrorIfTrueOrNull(this ResultGuard<bool?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!guard.Value.HasValue || guard.Value == true)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfTrueOrNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is equal to the target value.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target value to compare against.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool?> ErrorIfEqualTo(this ResultGuard<bool?> guard, bool? target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value == target)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is equal to the target value.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target value to compare against.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool> ErrorIfEqualTo(this ResultGuard<bool> guard, bool target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value == target)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is not equal to the target value.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target value to compare against.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool?> ErrorIfNotEqualTo(this ResultGuard<bool?> guard, bool? target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value != target)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfNotEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="bool"/> value is not equal to the target value.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target value to compare against.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<bool> ErrorIfNotEqualTo(this ResultGuard<bool> guard, bool target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value != target)
        {
            string resourceMessage = message ?? Resources.Boolean.BooleanResource.ErrorIfNotEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }
}