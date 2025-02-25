namespace PruebaGtMotive.Domain.Abstractions
{
    public abstract class Entity<TEntityId> : IEntity
    {

        private readonly List<IDomainEvent> _domainEvents = new();

        protected Entity() { }

        protected Entity(TEntityId id)
        {
            Id = id;
        }

        public TEntityId? Id { get; init; }    //init es que nunca va a cambiar
        public byte[]? Version { get; private set; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}