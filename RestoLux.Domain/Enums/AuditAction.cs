namespace RestoLux.Domain.Enums;

public enum AuditAction
{
    Create = 0,
    Update = 1,
    Delete = 2,
    Login = 3,
    Logout = 4,
    LoginFailed = 5,
    PasswordChanged = 6,
    StatusChanged = 7,
    Export = 8
}
