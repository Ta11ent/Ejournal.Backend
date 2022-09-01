using FluentValidation;
using System;

namespace Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails
{
    public class GetDepartmentDetailsQueryValidator : AbstractValidator<GetDepartmentDetailsQuery>
    {
        public GetDepartmentDetailsQueryValidator()
        {
            RuleFor(x => x.DepartmentId).NotEqual(Guid.Empty);
        }
    }
}
