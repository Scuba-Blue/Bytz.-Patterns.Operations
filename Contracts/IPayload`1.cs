using Bytz.Patterns.Operations.Bases;

namespace Bytz.Patterns.Operations.Contracts;

public interface IPayload<TPayload>
where TPayload : PayloadBase
{
    TPayload Payload { get; set; }
}