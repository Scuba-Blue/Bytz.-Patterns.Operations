using Bytz.Common.Exceptions;

namespace Bytz.Patterns.Operations.Exceptions;

/// <summary>
/// Exception will be thrown when testing for duplicate 
/// operation ordinals for a specific package.
/// </summary>
/// <remarks>
/// Constructor for the exception.
/// </remarks>
/// <param name="message">Message passed down to base.</param>
public class DuplicateOperationOrdinalException
(
    string message
)
: BytzExceptionBase(message)
{
    /// <summary>
    /// throw self 
    /// </summary>
    /// <exception cref="NotYetImplementedException"></exception>
    public static void Throw(string message)
    {
        throw new DuplicateOperationOrdinalException(message);
    }
}
