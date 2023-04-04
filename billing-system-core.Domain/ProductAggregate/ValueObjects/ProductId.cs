using billing_system_core.Domain.Common.Models;

namespace billing_system_core.Domain.ProductAggregate.ValueObjects;

public sealed class ProductId: ValueObject
{
    public Guid Value { get; }

    internal ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ProductId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}