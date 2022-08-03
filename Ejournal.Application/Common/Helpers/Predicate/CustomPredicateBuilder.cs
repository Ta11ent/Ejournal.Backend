using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ejournal.Application.Common.Helpers.Predicate
{
    internal static class CustomPredicateBuilder
    {
        internal static Expression<Func<T, bool>> True<T>() { return f => true; }
        internal static Expression<Func<T, bool>> And<T, P>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2, P request)
        {
            if (string.IsNullOrWhiteSpace(request.ToString()))
                expr2 = f => true;

            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
        internal static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {

            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}
