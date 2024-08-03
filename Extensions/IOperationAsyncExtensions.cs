using Bytz.Patterns.Operations.Asyncrhonous.Contracts;
using Bytz.Patterns.Operations.Bases;

namespace Bytz.Patterns.Operations.Extensions;

public static class IOperationAsyncExtensions
{
    /// <summary>
    /// Invoke operations for TPayload.
    /// </summary>
    /// <typeparam name="TPayload">Package for the operations to be invoked.</typeparam>
    /// <param name="operations">IEnumerable extension for IOperation<TPayload></param>
    /// <param name="set">Setter action for TPayload.</param>
    /// <param name="get">Getter action for TPayload.</param>
    public static async Task OperateAsync<TPayload>
    (
        this IEnumerable<IOperationAsync<TPayload>> operations,
        CancellationToken cancellationToken,
        Action<TPayload> set = null,
        Action<TPayload> get = null
    )
    where TPayload : PayloadBase, new()
    {
        TPayload payload = new();

        set?.Invoke(payload);

        IOrderedEnumerable<IOperationAsync<TPayload>> orderedOperations = operations
            .OrderBy(o => o.Ordinal);

        foreach (IOperationAsync<TPayload> operation in orderedOperations)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                break;
            }

            await operation.OperateAsync(payload, cancellationToken);
        }

        get?.Invoke(payload);
    }

    // testing
}