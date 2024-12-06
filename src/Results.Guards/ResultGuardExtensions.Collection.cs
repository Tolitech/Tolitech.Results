namespace Tolitech.Results.Guards;

/// <summary>
/// Provides extension methods for working with <see cref="ResultGuard"/>.
/// </summary>
public static partial class ResultGuardExtensions
{
    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified collection is null.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<IEnumerable<T>?> ErrorIfNull<T>(this ResultGuard<IEnumerable<T>?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null)
        {
            string resourceMessage = message ?? Resources.Collection.CollectionResource.ErrorIfNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified collection is not null.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<IEnumerable<T>?> ErrorIfNotNull<T>(this ResultGuard<IEnumerable<T>?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null)
        {
            string resourceMessage = message ?? Resources.Collection.CollectionResource.ErrorIfNotNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified collection is empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<IEnumerable<T>?> ErrorIfEmpty<T>(this ResultGuard<IEnumerable<T>?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value?.Any() == false)
        {
            string resourceMessage = message ?? Resources.Collection.CollectionResource.ErrorIfEmpty;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified collection is not empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<IEnumerable<T>?> ErrorIfNotEmpty<T>(this ResultGuard<IEnumerable<T>?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value?.Any() == true)
        {
            string resourceMessage = message ?? Resources.Collection.CollectionResource.ErrorIfNotEmpty;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the count of elements in the specified collection is equal to the specified count.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="count">The count to check for equality.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<IEnumerable<T>?> ErrorIfCountEqualTo<T>(this ResultGuard<IEnumerable<T>?> guard, int count, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Count() == count)
        {
            string resourceMessage = message ?? Resources.Collection.CollectionResource.ErrorIfCountEqualTo;
            message = TransformMessage(guard, message, resourceMessage, count);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the count of elements in the specified collection is not equal to the specified count.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="count">The count to check for inequality.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<IEnumerable<T>?> ErrorIfCountNotEqualTo<T>(this ResultGuard<IEnumerable<T>?> guard, int count, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Count() != count)
        {
            string resourceMessage = message ?? Resources.Collection.CollectionResource.ErrorIfCountNotEqualTo;
            message = TransformMessage(guard, message, resourceMessage, count);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the count of elements in the specified collection is greater than the specified count.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="count">The count to check for being less than or equal to.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<IEnumerable<T>?> ErrorIfCountGreaterThan<T>(this ResultGuard<IEnumerable<T>?> guard, int count, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Count() > count)
        {
            string resourceMessage = message ?? Resources.Collection.CollectionResource.ErrorIfCountGreaterThan;
            message = TransformMessage(guard, message, resourceMessage, count);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the count of elements in the specified collection is greater than or equal to the specified count.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="count">The count to check for being less than.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<IEnumerable<T>?> ErrorIfCountGreaterThanOrEqualTo<T>(this ResultGuard<IEnumerable<T>?> guard, int count, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Count() >= count)
        {
            string resourceMessage = message ?? Resources.Collection.CollectionResource.ErrorIfCountGreaterThanOrEqualTo;
            message = TransformMessage(guard, message, resourceMessage, count);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified collection count is less than the specified count.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="count">The minimum count allowed for the collection.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<IEnumerable<T>?> ErrorIfCountLessThan<T>(this ResultGuard<IEnumerable<T>?> guard, int count, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Count() < count)
        {
            string resourceMessage = message ?? Resources.Collection.CollectionResource.ErrorIfCountLessThan;
            message = TransformMessage(guard, message, resourceMessage, count);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified collection count is less than or equal to the specified count.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="count">The maximum count allowed for the collection.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<IEnumerable<T>?> ErrorIfCountLessThanOrEqualTo<T>(this ResultGuard<IEnumerable<T>?> guard, int count, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Count() <= count)
        {
            string resourceMessage = message ?? Resources.Collection.CollectionResource.ErrorIfCountLessThanOrEqualTo;
            message = TransformMessage(guard, message, resourceMessage, count);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }
}