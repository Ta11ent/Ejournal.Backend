using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkDetails
{
    public class GetHomeWorkDetailsQueryValidator : AbstractValidator<GetHomeWorkDetailsQuery>
    {
        public GetHomeWorkDetailsQueryValidator()
        {
            RuleFor(x => x.HomeWorkId).NotEqual(Guid.Empty);
        }
    }
}
