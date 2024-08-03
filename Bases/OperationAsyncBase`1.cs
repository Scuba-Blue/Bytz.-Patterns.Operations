using Bytz.Patterns.Operations.Asyncrhonous.Contracts;

namespace Bytz.Patterns.Operations.Bases;

public abstract class OperationAsyncBase<TPackage>
: OperationBase, IOperationAsync<TPackage>
where TPackage : PayloadBase, new()
{
    public TPackage Payload { get; set; }

    protected abstract Task OnOperateAsync(TPackage payload, CancellationToken cancellationToken);

    public async Task OperateAsync(PayloadBase package, CancellationToken cancellationToken)
    {
        Payload = (TPackage)package;

        if (CanRun && !cancellationToken.IsCancellationRequested)
        {
            await OnOperateAsync(Payload, cancellationToken);
        }
    }
}