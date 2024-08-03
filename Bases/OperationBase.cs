using Bytz.Patterns.Operations.Contracts;

namespace Bytz.Patterns.Operations.Bases;

public abstract class OperationBase
: IOperation
{
    public abstract bool CanRun { get; }

    public abstract short Ordinal { get; }
}
