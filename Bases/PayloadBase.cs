namespace Bytz.Patterns.Operations.Bases;

/// <summary>
/// basis for all operational payloads.
/// </summary>
public abstract class PayloadBase
{
    /// <summary>
    /// to hold an exception if thrown.
    /// </summary>
    public Exception Exception { get; set; }
}