

using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Specifications;

public static class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(
        IQueryable<T> inputQuery,
        ISpecification<T> specification
        )

    {
       var query = inputQuery;
        if (specification.Criteria is not null)
        
            query = query.Where(specification.Criteria);
        
        if(specification.Includes is not null)

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));


        if(specification.OrderBy is not null)
            query = query.OrderBy(specification.OrderBy);

        if(specification.OrderByDescending is not null)
            query = query.OrderByDescending(specification.OrderByDescending);

        if(specification.IsPagingEnabled)
            query = query.Skip(specification.Skip).Take(specification.Take);

        return query;
    }

}


