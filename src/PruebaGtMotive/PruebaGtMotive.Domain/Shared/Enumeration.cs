
namespace PruebaGtMotive.Domain.Shared;

public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
where TEnum : Enumeration<TEnum>
{
    private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

    

    public int Id{get; protected init;}
    public string Name{get; protected init;} = string.Empty;
    protected Enumeration(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static TEnum? FromValue(int id)
    {
        return Enumerations.TryGetValue(id, out TEnum?  enumeration) ? enumeration : default;
    }

     public static TEnum? FromName(string name)
    {
        return Enumerations.Values.SingleOrDefault(x => x.Name == name);

    }

    public static List<TEnum> GetValues()
    {
        return Enumerations.Values.ToList();
    }

    public bool Equals(Enumeration<TEnum>? other)
    {
        if(other is null)
        {
            return false;
        }
        // comprar el rol y su id
        return GetType() == other.GetType() && Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Enumeration<TEnum> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }

    private static Dictionary<int, TEnum> CreateEnumerations()
    {
        var enumerationType = typeof(TEnum); // que tipo de objeto es TEnum?

        // obtener las propiedades de la clase
        var fieldsForType = enumerationType.GetFields(
            System.Reflection.BindingFlags.Public |
            System.Reflection.BindingFlags.Static |
            System.Reflection.BindingFlags.FlattenHierarchy
        ).Where(fieldInfo => enumerationType.IsAssignableFrom(fieldInfo.FieldType))
        .Select(fieldInfo => (TEnum) fieldInfo.GetValue(default)!)
        ;

        return fieldsForType.ToDictionary(x => x.Id);
    }
}
