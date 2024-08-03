namespace Bytz.Patterns.Operations.Contracts;

/// <summary>
/// base contract for operations.
/// </summary>
public interface IOperation
{
    /// <summary>
    /// should the operation run or not.
    /// </summary>
    bool CanRun { get; }

    /// <summary>
    /// order of the operation in a list of like operations.
    /// </summary>
    short Ordinal { get; }
}