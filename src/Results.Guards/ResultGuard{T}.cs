namespace Tolitech.Results.Guards;

/// <summary>
/// Represents a guard class used for validating values within the context of a Result.
/// </summary>
/// <typeparam name="T">The type of the value being guarded.</typeparam>
public class ResultGuard<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResultGuard{T}"/> class.
    /// </summary>
    /// <param name="result">The Result instance associated with the guard.</param>
    /// <param name="value">The value being guarded.</param>
    /// <param name="propertyName">The name of the property associated with the value.</param>
    internal ResultGuard(Result result, T? value, string propertyName)
    {
        Result = result;
        Value = value;
        PropertyName = propertyName;
    }

    /// <summary>
    /// Gets the value being guarded.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Gets the Result instance associated with the guard.
    /// </summary>
    internal Result Result { get; }

    /// <summary>
    /// Gets the name of the property associated with the value.
    /// </summary>
    internal string PropertyName { get; }
}