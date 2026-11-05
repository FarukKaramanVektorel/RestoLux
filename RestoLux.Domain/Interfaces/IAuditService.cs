using RestoLux.Domain.Enums;

namespace RestoLux.Domain.Interfaces;

public interface IAuditService
{
    Task LogAsync(AuditAction action, string entityName, string? entityId = null, string? oldValues = null, string? newValues = null, CancellationToken cancellationToken = default);
}
