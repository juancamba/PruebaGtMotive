

using PruebaGtMotive.Application.Abstractions.Clock;

namespace PruebaGtMotive.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime currentTime => DateTime.UtcNow;
}