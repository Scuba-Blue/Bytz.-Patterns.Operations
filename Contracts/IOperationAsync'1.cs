using Bytz.Patterns.Operations.Bases;
using Bytz.Patterns.Operations.Contracts;

namespace Bytz.Patterns.Operations.Asyncrhonous.Contracts;
public interface IOperationAsync<TPayload>
: IOperation, IPayload<TPayload>
where TPayload : PayloadBase, new()
{
    Task OperateAsync(PayloadBase package, CancellationToken cancellationToken);
}