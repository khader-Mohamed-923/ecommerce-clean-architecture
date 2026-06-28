

using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.Data.DbContexts;
using ECommerce.Infrastructure.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Repositories;

public class Repository<T>(StoreDbContext context) : IRepository<T> where T : BaseEntity
{
    

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
                  => await context.Set<T>().FindAsync(id, cancellationToken);
    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
                  => await context.Set<T>().ToListAsync(cancellationToken);


    public void Add(T entity)
         => context.Set<T>().Add(entity);

    public void Delete(T entity)
               => context.Set<T>().Remove(entity);


    public void Update(T entity)
              => context.Set<T>().Update(entity);

    public async Task<T?> GetEntityWithSpecAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
              => await SpecificationEvaluator<T>
                         .GetQuery(context.Set<T>(), specification)
                         .FirstOrDefaultAsync(cancellationToken);

    public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
             => await SpecificationEvaluator<T>
                         .GetQuery(context.Set<T>(), specification)
                         .ToListAsync(cancellationToken);

    public Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
             => SpecificationEvaluator<T>
                         .GetQuery(context.Set<T>(), specification)
                         .CountAsync(cancellationToken);
}
