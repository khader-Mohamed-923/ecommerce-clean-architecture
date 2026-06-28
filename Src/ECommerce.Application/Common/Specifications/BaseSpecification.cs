
using ECommerce.Domain.Interfaces;
using System.Linq.Expressions;

namespace ECommerce.Application.Common.Specifications;

public abstract class BaseSpecification<T> : ISpecification<T>
{
    private readonly List<Expression<Func<T, object>>> _includes = [];

    public Expression<Func<T, bool>>? Criteria { get; private set; }
    public IReadOnlyList<Expression<Func<T, object>>> Includes => _includes;

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    public int Take { get; private set; }

    public int Skip { get; private set; }

    public bool IsPagingEnabled { get; private set; }


    protected BaseSpecification() { }
    protected BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected void AddInclude(Expression<Func<T, object>> include)

        => _includes.Add(include);


    protected void AddOrderBy(Expression<Func<T, object>> orderBy)
        => OrderBy = orderBy;

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
        => OrderByDescending = orderByDescending;


    protected void ApplyPaging(int pageIndex, int pageSize)
    {
        Skip = pageIndex * pageSize;
        Take = pageSize;
        IsPagingEnabled = true;
    }

}

