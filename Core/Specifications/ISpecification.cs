using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        // Func takes in a type and what it is returning
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }

        // Pagination properties:
        // If first page, then take 5, skip 0
        // If second page, then take 5, skip 5
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}