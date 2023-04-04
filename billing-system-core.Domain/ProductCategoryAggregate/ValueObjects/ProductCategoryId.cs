using billing_system_core.Domain.Common.Models;

namespace billing_system_core.Domain.ProductCategoryAggregate.ValueObjects;

public sealed class ProductCategoryId: ValueObject
{
    public Guid Value { get; }

    private ProductCategoryId(Guid value)
    {
        Value = value;
    }

    public static ProductCategoryId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ProductCategoryId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}