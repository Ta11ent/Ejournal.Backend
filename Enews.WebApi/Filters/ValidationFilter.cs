using FluentValidation;

namespace Enews.WebApi.Filters
{
    public class ValidationFilter<T> : IEndpointFilter where T : class
    {
        private readonly IValidator<T> _validator;
        public ValidationFilter(IValidator<T> validator) => _validator = validator;

        
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var entity = context.Arguments
                .FirstOrDefault(x => x.GetType() == typeof(T)) as T;
            var result = await _validator.ValidateAsync(entity!);
            if (!result.IsValid)
                return Results.Json(result.Errors, statusCode: 400);

            return await next(context);
        }
    }
}
