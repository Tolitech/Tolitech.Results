namespace Tolitech.Results.Guards;

/// <summary>
/// Provides extension methods for working with <see cref="ResultGuard"/>.
/// </summary>
public static partial class ResultGuardExtensions
{
    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateTime"/> value is in the future.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime?> ErrorIfFuture(this ResultGuard<DateTime?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value > DateTime.Now)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateTime"/> value is in the future.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime> ErrorIfFuture(this ResultGuard<DateTime> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value > DateTime.Now)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateOnly"/> value is in the future.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly?> ErrorIfFuture(this ResultGuard<DateOnly?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value > DateOnly.FromDateTime(DateTime.Today))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateOnly"/> value is in the future.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly> ErrorIfFuture(this ResultGuard<DateOnly> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value > DateOnly.FromDateTime(DateTime.Today))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateTime"/> value is in the future (UTC).
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime?> ErrorIfFutureUtc(this ResultGuard<DateTime?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value > DateTime.UtcNow)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateTime"/> value is in the future (UTC).
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime> ErrorIfFutureUtc(this ResultGuard<DateTime> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value > DateTime.UtcNow)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateOnly"/> value is in the future (UTC).
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly?> ErrorIfFutureUtc(this ResultGuard<DateOnly?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value > DateOnly.FromDateTime(DateTime.UtcNow))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateOnly"/> value is in the future (UTC).
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly> ErrorIfFutureUtc(this ResultGuard<DateOnly> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value > DateOnly.FromDateTime(DateTime.UtcNow))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the future.
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime?> ErrorIfNotFuture(this ResultGuard<DateTime?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value <= DateTime.Now)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the future.
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime> ErrorIfNotFuture(this ResultGuard<DateTime> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value <= DateTime.Now)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the future.
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly?> ErrorIfNotFuture(this ResultGuard<DateOnly?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value <= DateOnly.FromDateTime(DateTime.Today))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the future.
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly> ErrorIfNotFuture(this ResultGuard<DateOnly> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value <= DateOnly.FromDateTime(DateTime.Today))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the future (UTC).
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime?> ErrorIfNotFutureUtc(this ResultGuard<DateTime?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value <= DateTime.UtcNow)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the future (UTC).
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime> ErrorIfNotFutureUtc(this ResultGuard<DateTime> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value <= DateTime.UtcNow)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the future (UTC).
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly?> ErrorIfNotFutureUtc(this ResultGuard<DateOnly?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value <= DateOnly.FromDateTime(DateTime.UtcNow))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the future (UTC).
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly> ErrorIfNotFutureUtc(this ResultGuard<DateOnly> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value <= DateOnly.FromDateTime(DateTime.UtcNow))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotFuture;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateTime"/> value is in the past.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime?> ErrorIfPast(this ResultGuard<DateTime?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value < DateTime.Now)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateTime"/> value is in the past.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime> ErrorIfPast(this ResultGuard<DateTime> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value < DateTime.Now)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateOnly"/> value is in the past.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly?> ErrorIfPast(this ResultGuard<DateOnly?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value < DateOnly.FromDateTime(DateTime.Today))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateOnly"/> value is in the past.
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly> ErrorIfPast(this ResultGuard<DateOnly> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value < DateOnly.FromDateTime(DateTime.Today))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateTime"/> value is in the past (UTC).
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime?> ErrorIfPastUtc(this ResultGuard<DateTime?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value < DateTime.UtcNow)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateTime"/> value is in the past (UTC).
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime> ErrorIfPastUtc(this ResultGuard<DateTime> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value < DateTime.UtcNow)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateOnly"/> value is in the past (UTC).
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly?> ErrorIfPastUtc(this ResultGuard<DateOnly?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value < DateOnly.FromDateTime(DateTime.UtcNow))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified <see cref="DateOnly"/> value is in the past (UTC).
    /// </summary>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly> ErrorIfPastUtc(this ResultGuard<DateOnly> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value < DateOnly.FromDateTime(DateTime.UtcNow))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the past.
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime?> ErrorIfNotPast(this ResultGuard<DateTime?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value >= DateTime.Now)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the past.
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime> ErrorIfNotPast(this ResultGuard<DateTime> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value >= DateTime.Now)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the past.
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly?> ErrorIfNotPast(this ResultGuard<DateOnly?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value >= DateOnly.FromDateTime(DateTime.Today))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the past.
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly> ErrorIfNotPast(this ResultGuard<DateOnly> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value >= DateOnly.FromDateTime(DateTime.Today))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the past (UTC).
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime?> ErrorIfNotPastUtc(this ResultGuard<DateTime?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value >= DateTime.UtcNow)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the past (UTC).
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateTime> ErrorIfNotPastUtc(this ResultGuard<DateTime> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value >= DateTime.UtcNow)
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the past (UTC).
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly?> ErrorIfNotPastUtc(this ResultGuard<DateOnly?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null && guard.Value.Value >= DateOnly.FromDateTime(DateTime.UtcNow))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error to the result if the provided value is not in the past (UTC).
    /// </summary>
    /// <param name="guard">The result guard.</param>
    /// <param name="statusCode">The optional status code for the error (default is <see cref="StatusCode.BadRequest"/>).</param>
    /// <param name="key">The optional key associated with the error (default is <c>null</c>).</param>
    /// <param name="message">The optional error message (default is <c>null</c>).</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<DateOnly> ErrorIfNotPastUtc(this ResultGuard<DateOnly> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value >= DateOnly.FromDateTime(DateTime.UtcNow))
        {
            string resourceMessage = message ?? Resources.DateTime.DateTimeResource.ErrorIfNotPast;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }
}