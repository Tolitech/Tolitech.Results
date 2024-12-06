using System.Globalization;
using System.Runtime.CompilerServices;

namespace Tolitech.Results.Guards;

/// <summary>
/// Provides extension methods for working with the <see cref="ResultGuard{T}"/> class.
/// </summary>
public static partial class ResultGuardExtensions
{
    /// <summary>
    /// Guards the specified value and associates it with the <see cref="Result"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="result">The <see cref="Result"/> instance.</param>
    /// <param name="value">The value to be guarded.</param>
    /// <param name="propertyName">The name of the property associated with the value. Defaults to null.</param>
    /// <param name="name">The name of the property, provided automatically by the compiler. Do not specify this parameter explicitly.</param>
    /// <returns>The <see cref="ResultGuard{T}"/> instance.</returns>
    /// <remarks>
    /// This method is used to guard a value within the context of a <see cref="Result"/>.
    /// It creates a <see cref="ResultGuard{T}"/> instance, associating the value and property name with the provided <see cref="Result"/> instance.
    /// </remarks>
    public static ResultGuard<T?> Guard<T>(this Result result, T? value, string? propertyName = null, [CallerArgumentExpression(nameof(value))] string name = "")
    {
        return ResultGuard.Create(result, value, propertyName ?? name);
    }

    /// <summary>
    /// Ends the guard block, throwing an exception if the guard is null.
    /// </summary>
    /// <typeparam name="T">The type of the value being guarded.</typeparam>
    /// <param name="guard">The ResultGuard instance.</param>
    public static void End<T>(this ResultGuard<T?> guard)
    {
        ArgumentNullException.ThrowIfNull(guard);
    }

    /// <summary>
    /// Transforms the error message using the provided parameters or the default property name.
    /// </summary>
    /// <typeparam name="T">The type of the value being guarded.</typeparam>
    /// <param name="guard">The ResultGuard instance.</param>
    /// <param name="message">The custom error message.</param>
    /// <param name="resourceMessage">The resource-based error message.</param>
    /// <param name="parameters">Additional parameters for formatting the error message.</param>
    /// <returns>The transformed error message.</returns>
    public static string TransformMessage<T>(this ResultGuard<T?> guard, string? message, string resourceMessage, params object?[] parameters)
    {
        ArgumentNullException.ThrowIfNull(guard);

        if (string.IsNullOrEmpty(message) && parameters?.Length > 0)
        {
            List<object?> list = [guard.PropertyName, .. parameters];
            object?[] mergedParams = [.. list];

            return string.Format(CultureInfo.CurrentCulture, resourceMessage, mergedParams);
        }

        return message ?? string.Format(CultureInfo.CurrentCulture, resourceMessage, guard.PropertyName);
    }

    /// <summary>
    /// Adds an error to the associated Result instance using the specified key, message, and status code.
    /// </summary>
    /// <typeparam name="T">The type of the value being guarded.</typeparam>
    /// <param name="guard">The ResultGuard instance.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The error message.</param>
    /// <param name="statusCode">The status code associated with the error.</param>
    public static void AddError<T>(this ResultGuard<T?> guard, string? key, string message, StatusCode statusCode)
    {
        ArgumentNullException.ThrowIfNull(guard);

        AddError(guard.Result, key ?? guard.PropertyName, message, statusCode);
    }

    /// <summary>
    /// Adds an error to the specified Result instance using the specified key, message, and status code.
    /// </summary>
    /// <param name="result">The Result instance to which the error will be added.</param>
    /// <param name="key">The key associated with the error.</param>
    /// <param name="message">The error message.</param>
    /// <param name="statusCode">The status code associated with the error.</param>
    private static void AddError(Result result, string? key, string message, StatusCode statusCode)
    {
        result.AddError(key, message, statusCode);
    }
}