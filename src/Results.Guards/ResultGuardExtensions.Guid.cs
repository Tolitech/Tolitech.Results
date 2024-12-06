namespace Tolitech.Results.Guards;

/// <summary>
/// Provides extension methods for working with <see cref="ResultGuard"/>.
/// </summary>
public static partial class ResultGuardExtensions
{
    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="Guid"/> value is null.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<Guid?> ErrorIfNull(this ResultGuard<Guid?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null)
        {
            string resourceMessage = message ?? Resources.Guid.GuidResource.ErrorIfNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="Guid"/> value is not null.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<Guid?> ErrorIfNotNull(this ResultGuard<Guid?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null)
        {
            string resourceMessage = message ?? Resources.Guid.GuidResource.ErrorIfNotNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="Guid"/> value is equal to the target value.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target <see cref="Guid"/> value for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<Guid?> ErrorIfEqualTo(this ResultGuard<Guid?> guard, Guid? target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value == target)
        {
            string resourceMessage = message ?? Resources.Guid.GuidResource.ErrorIfEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="Guid"/> value is equal to the target value.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target <see cref="Guid"/> value for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<Guid> ErrorIfEqualTo(this ResultGuard<Guid> guard, Guid target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value == target)
        {
            string resourceMessage = message ?? Resources.Guid.GuidResource.ErrorIfEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="Guid"/> value is not equal to the target value.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target <see cref="Guid"/> value for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<Guid?> ErrorIfNotEqualTo(this ResultGuard<Guid?> guard, Guid? target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value != target)
        {
            string resourceMessage = message ?? Resources.Guid.GuidResource.ErrorIfNotEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="Guid"/> value is not equal to the target value.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target <see cref="Guid"/> value for comparison.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<Guid> ErrorIfNotEqualTo(this ResultGuard<Guid> guard, Guid target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value != target)
        {
            string resourceMessage = message ?? Resources.Guid.GuidResource.ErrorIfNotEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="Guid"/> value is null or empty.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<Guid?> ErrorIfNullOrEmpty(this ResultGuard<Guid?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null || guard.Value.Value == Guid.Empty)
        {
            string resourceMessage = message ?? Resources.Guid.GuidResource.ErrorIfNullOrEmpty;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="Guid"/> value is not null or empty.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<Guid?> ErrorIfNotNullOrNotEmpty(this ResultGuard<Guid?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!(guard.Value is null || guard.Value.Value == Guid.Empty))
        {
            string resourceMessage = message ?? Resources.Guid.GuidResource.ErrorIfNotNullOrNotEmpty;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }
}