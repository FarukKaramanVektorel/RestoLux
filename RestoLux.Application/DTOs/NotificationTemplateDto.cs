using RestoLux.Domain.Entities;
using RestoLux.Domain.Enums;

namespace RestoLux.Application.DTOs;

public record NotificationTemplateDto(int Id, string TemplateName, string? Subject, string Body, NotificationType Type, string Culture, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt);
public record CreateNotificationTemplateDto(string TemplateName, string? Subject, string Body, NotificationType Type, string Culture = "tr", bool IsActive = true);
public record UpdateNotificationTemplateDto(string TemplateName, string? Subject, string Body, NotificationType Type, string Culture, bool IsActive);

public static class NotificationTemplateMappings
{
    public static NotificationTemplateDto ToDto(this NotificationTemplate e) => new(e.Id, e.TemplateName, e.Subject, e.Body, e.Type, e.Culture, e.IsActive, e.CreatedAt, e.UpdatedAt);
    public static NotificationTemplate ToEntity(this CreateNotificationTemplateDto d) => new() { TemplateName = d.TemplateName, Subject = d.Subject, Body = d.Body, Type = d.Type, Culture = d.Culture, IsActive = d.IsActive };
    public static void Apply(this UpdateNotificationTemplateDto d, NotificationTemplate e) { e.TemplateName = d.TemplateName; e.Subject = d.Subject; e.Body = d.Body; e.Type = d.Type; e.Culture = d.Culture; e.IsActive = d.IsActive; }
}