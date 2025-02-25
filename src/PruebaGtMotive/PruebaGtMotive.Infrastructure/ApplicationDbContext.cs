


using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaGtMotive.Application.Exceptions;
using PruebaGtMotive.Domain.Abstractions;

namespace PruebaGtMotive.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;
    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); //escane cada una de las configuraciones en /configurations
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            
            await PublishDomainEventsAsync();
            
            return result;    
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Excetion por concurrencia se disparó", ex);
        }
        
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<IEntity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity => {
                var domainEvents = entity.GetDomainEvents();
                entity.ClearDomainEvents();
                return domainEvents;
            
            }).ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }    
    }
}
