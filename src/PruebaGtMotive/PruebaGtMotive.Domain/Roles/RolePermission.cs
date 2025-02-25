


using PruebaGtMotive.Domain.Permissions;

namespace PruebaGtMotive.Domain.Roles;

public sealed class RolePermission
{
    public int RoleId{get;set;}
    public PermissionId? PermissionId {get;set;}
}
