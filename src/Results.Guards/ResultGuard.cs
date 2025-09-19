namespace Tolitech.Results.Guards;

/// <summary>
/// Represents a factory method for creating instances of the <see cref="ResultGuard"/> class.
/// </summary>
public static class ResultGuard
{
    /// <summary>
    /// Creates a new instance of the <see cref="ResultGuard{T}"/> class.
    /// </summary>
    /// <typeparam name="T">The type of the value being guarded.</typeparam>
    /// <param name="result">The Result instance associated with the guard.</param>
    /// <param name="value">The value being guarded.</param>
    /// <param name="propertyName">The name of the property associated with the value.</param>
    /// <returns>A new instance of <see cref="ResultGuard{T}"/>.</returns>
    public static ResultGuard<T?> Create<T>(IResult result, T? value, string propertyName)
    {
        return new(result, value, propertyName);
    }
}