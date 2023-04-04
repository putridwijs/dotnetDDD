using billing_system_core.Application.Common.Interface.Services;

namespace billing_system_core.Infrastructure.Services;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}