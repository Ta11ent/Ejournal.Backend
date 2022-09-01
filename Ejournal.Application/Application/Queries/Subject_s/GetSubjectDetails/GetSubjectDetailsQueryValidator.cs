using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectDetails
{
    public class GetSubjectDetailsQueryValidator : AbstractValidator<GetSubjectDetailsQuery>
    {
        public GetSubjectDetailsQueryValidator()
        {
            RuleFor(x => x.SubjectId).NotEqual(Guid.Empty);
        }
    }
}
