


using PruebaGtMotive.Domain.Abstractions;

namespace PruebaGtMotive.Domain.Permissions;

public sealed class Permission : Entity<PermissionId>
{
    private Permission()
    {
        
    }

    public Permission(PermissionId id, Nombre nombre) : base(id)
    {
        //el id se genera en db
        Nombre = nombre;
    }

    public Permission(Nombre nombre)
    {
        Nombre = nombre;
    }

    public Nombre? Nombre {get;init;}

    public static Result<Permission> Create(Nombre nombre)
    {
        return new Permission(nombre);
    }
}
