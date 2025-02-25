using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaGtMotive.Domain.Abstractions;
using PruebaGtMotive.Domain.Users.Events;

namespace PruebaGtMotive.Domain.Users;

public class User : Entity<UserId>
{

    public Nombre? Nombre { get; private set; }
    public Apellido? Apellido { get; private set; }
    public Email? Email { get; private set; }
    public PasswordHash? PasswordHash { get; private set; }

    private User(UserId id, Nombre? nombre, Apellido? apellido, Email? email, PasswordHash passwordHash) : base(id)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        PasswordHash = passwordHash;
    }

    private User() { }

    public static User Create(Nombre nombre, Apellido apellido, Email email, PasswordHash passwordHash)
    {
        var user = new User(UserId.New(), nombre, apellido, email, passwordHash);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id!));
        return user;
    }



}
