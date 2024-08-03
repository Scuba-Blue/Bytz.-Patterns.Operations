using Bytz.Patterns.Operations.Bases;
using Bytz.Patterns.Operations.Contracts;
using Bytz.Patterns.Operations.Exceptions;
using System.Text;

namespace Bytz.Patterns.Operations.Extensions;
public static class IOperationExtensions
{
    public static void Operate<TPayload>
    (
        this IEnumerable<IOperation<TPayload>> operations,
        Action<TPayload> set,
        Action<TPayload> get
    )
     where TPayload : PayloadBase, new()
    {
        TPayload payload = new();

        set?.Invoke(payload);

        IOrderedEnumerable<IOperation<TPayload>> orderedOperations = operations
            .OrderBy(o => o.Ordinal);

        foreach (IOperation<TPayload> ordered in orderedOperations)
        {
            ordered.Operate(payload);
        }

        get?.Invoke(payload);
    }

    /// <summary>
    /// Assert that the operations for this package have unique values.
    /// </summary>
    public static void AssertUniqueOrdinals<TPayload>
    (
        this IEnumerable<IOperation<TPayload>> operations
    )
    where TPayload : PayloadBase, new()
    {
        IEnumerable<IGrouping<short, IOperation<TPayload>>> duplicates = operations
            .GroupBy(b => b.Ordinal)
            .Where(g => g.Count() > 1);

        if (duplicates.Any())
        {
            string message = duplicates
                .Aggregate
                (
                    new StringBuilder(),
                    (current, next) => current.AppendLine($"Ordinal={next.Key}\t{next.ElementAt(0).GetType().Name}\t<=>\t{next.ElementAt(1).GetType().Name}")
                )
                .ToString();

            DuplicateOperationOrdinalException.Throw(message);
        }
    }
}