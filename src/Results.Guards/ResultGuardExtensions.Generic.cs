namespace Tolitech.Results.Guards;

/// <summary>
/// Provides extension methods for working with <see cref="ResultGuard"/>.
/// </summary>
public static partial class ResultGuardExtensions
{
    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified value is null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T?> ErrorIfNull<T>(this ResultGuard<T?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified value is not null.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T?> ErrorIfNotNull<T>(this ResultGuard<T?> guard, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is not null)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfNotNull;
            message = TransformMessage(guard, message, resourceMessage);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified value is equal to the target value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target value to compare against.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T?> ErrorIfEqualTo<T>(this ResultGuard<T?> guard, T? target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if ((guard.Value is not null && target is null) || (guard.Value is null && target is not null))
        {
            return guard;
        }

        if (guard.Value.Equals(target))
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified value is equal to the target value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target value to compare against.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T> ErrorIfEqualTo<T>(this ResultGuard<T> guard, T target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value.Equals(target))
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified value is not equal to the target value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target value to compare against.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T?> ErrorIfNotEqualTo<T>(this ResultGuard<T?> guard, T? target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null && target is null)
        {
            return guard;
        }

        if (guard.Value is null || target is null || !guard.Value.Equals(target))
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfNotEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error message to the <see cref="Result"/> if the specified value is not equal to the target value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="target">The target value to compare against.</param>
    /// <param name="statusCode">The status code to be used if the error condition is met. Defaults to BadRequest (400).</param>
    /// <param name="key">The key associated with the error message. Defaults to null.</param>
    /// <param name="message">The custom error message. Defaults to null.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T> ErrorIfNotEqualTo<T>(this ResultGuard<T> guard, T target, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!guard.Value.Equals(target))
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfNotEqualTo;
            message = TransformMessage(guard, message, resourceMessage, target);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is less than the specified <paramref name="maximum"/> value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="maximum">The maximum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T?> ErrorIfLessThan<T>(this ResultGuard<T?> guard, T? maximum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null || maximum is null)
        {
            return guard;
        }

        if (guard.Value.Value.CompareTo(maximum.Value) < 0)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfLessThan;
            message = TransformMessage(guard, message, resourceMessage, maximum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is less than the specified <paramref name="maximum"/> value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="maximum">The maximum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T> ErrorIfLessThan<T>(this ResultGuard<T> guard, T maximum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value.CompareTo(maximum) < 0)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfLessThan;
            message = TransformMessage(guard, message, resourceMessage, maximum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is less than or equal to the specified <paramref name="maximum"/> value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="maximum">The maximum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T?> ErrorIfLessThanOrEqualTo<T>(this ResultGuard<T?> guard, T? maximum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null || maximum is null)
        {
            return guard;
        }

        if (guard.Value.Value.CompareTo(maximum.Value) <= 0)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfLessThanOrEqualTo;
            message = TransformMessage(guard, message, resourceMessage, maximum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is less than or equal to the specified <paramref name="maximum"/> value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="maximum">The maximum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T> ErrorIfLessThanOrEqualTo<T>(this ResultGuard<T> guard, T maximum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value.CompareTo(maximum) <= 0)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfLessThanOrEqualTo;
            message = TransformMessage(guard, message, resourceMessage, maximum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is greater than the specified <paramref name="minimum"/> value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="minimum">The minimum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T?> ErrorIfGreaterThan<T>(this ResultGuard<T?> guard, T? minimum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null || minimum is null)
        {
            return guard;
        }

        if (guard.Value.Value.CompareTo(minimum.Value) > 0)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfGreaterThan;
            message = TransformMessage(guard, message, resourceMessage, minimum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is greater than the specified <paramref name="minimum"/> value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="minimum">The minimum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T> ErrorIfGreaterThan<T>(this ResultGuard<T> guard, T minimum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value.CompareTo(minimum) > 0)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfGreaterThan;
            message = TransformMessage(guard, message, resourceMessage, minimum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is greater than or equal to the specified <paramref name="minimum"/> value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="minimum">The minimum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T?> ErrorIfGreaterThanOrEqualTo<T>(this ResultGuard<T?> guard, T? minimum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null || minimum is null)
        {
            return guard;
        }

        if (guard.Value.Value.CompareTo(minimum.Value) >= 0)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfGreaterThanOrEqualTo;
            message = TransformMessage(guard, message, resourceMessage, minimum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is greater than or equal to the specified <paramref name="minimum"/> value.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="minimum">The minimum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T> ErrorIfGreaterThanOrEqualTo<T>(this ResultGuard<T> guard, T minimum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value.CompareTo(minimum) >= 0)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfGreaterThanOrEqualTo;
            message = TransformMessage(guard, message, resourceMessage, minimum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is not between the specified <paramref name="minimum"/> and <paramref name="maximum"/> values (inclusive).
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="minimum">The minimum value for comparison.</param>
    /// <param name="maximum">The maximum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T?> ErrorIfBetween<T>(this ResultGuard<T?> guard, T? minimum, T? maximum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null || minimum is null || maximum is null)
        {
            return guard;
        }

        if (guard.Value.Value.CompareTo(minimum.Value) >= 0 && guard.Value.Value.CompareTo(maximum.Value) <= 0)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfBetween;
            message = TransformMessage(guard, message, resourceMessage, minimum, maximum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is not between the specified <paramref name="minimum"/> and <paramref name="maximum"/> values (inclusive).
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="minimum">The minimum value for comparison.</param>
    /// <param name="maximum">The maximum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T> ErrorIfBetween<T>(this ResultGuard<T> guard, T minimum, T maximum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value.CompareTo(minimum) >= 0 && guard.Value.CompareTo(maximum) <= 0)
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfBetween;
            message = TransformMessage(guard, message, resourceMessage, minimum, maximum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is between the specified <paramref name="minimum"/> and <paramref name="maximum"/> values (inclusive).
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="minimum">The minimum value for comparison.</param>
    /// <param name="maximum">The maximum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T?> ErrorIfNotBetween<T>(this ResultGuard<T?> guard, T? minimum, T? maximum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (guard.Value is null || minimum is null || maximum is null)
        {
            return guard;
        }

        if (!(guard.Value.Value.CompareTo(minimum.Value) >= 0 && guard.Value.Value.CompareTo(maximum.Value) <= 0))
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfNotBetween;
            message = TransformMessage(guard, message, resourceMessage, minimum, maximum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }

    /// <summary>
    /// Adds an error if the specified value is between the specified <paramref name="minimum"/> and <paramref name="maximum"/> values (inclusive).
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="guard">The <see cref="ResultGuard"/> instance.</param>
    /// <param name="minimum">The minimum value for comparison.</param>
    /// <param name="maximum">The maximum value for comparison.</param>
    /// <param name="statusCode">The status code for the error.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The custom error message.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance, allowing for method chaining.</returns>
    public static ResultGuard<T> ErrorIfNotBetween<T>(this ResultGuard<T> guard, T minimum, T maximum, StatusCode statusCode = StatusCode.BadRequest, string? key = null, string? message = null)
        where T : struct, IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (!(guard.Value.CompareTo(minimum) >= 0 && guard.Value.CompareTo(maximum) <= 0))
        {
            string resourceMessage = message ?? Resources.Generic.GenericResource.ErrorIfNotBetween;
            message = TransformMessage(guard, message, resourceMessage, minimum, maximum);
            AddError(guard, key, message, statusCode);
        }

        return guard;
    }
}