using Bytz.Patterns.Operations.Bases;

namespace Bytz.Patterns.Operations.Contracts;

public interface IOperation<TPayload>
: IOperation, IPayload<TPayload>
where TPayload : PayloadBase, new()
{
    void Operate(PayloadBase payload);
}