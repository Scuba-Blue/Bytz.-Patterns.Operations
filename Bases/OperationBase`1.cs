using Bytz.Patterns.Operations.Contracts;

namespace Bytz.Patterns.Operations.Bases;

public abstract class OperationBase<TPayload>
: OperationBase, IOperation<TPayload>
where TPayload : PayloadBase, new()
{
    public TPayload Payload { get; set; }

    protected abstract void OnOperate(TPayload payload);

    public void Operate
    (
        PayloadBase payload
    )
    {
        Payload = (TPayload)payload;

        if (CanRun)
        {
            OnOperate(Payload);
        }
    }
}