using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.RatingLog_s.CreateRatingLog
{
    public class CreateRatingLogCommandValidator : AbstractValidator<CreateRatingLogCommand>
    {
        public CreateRatingLogCommandValidator()
        {
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
            RuleFor(x => x.SubjectId).NotEqual(Guid.Empty);
            RuleFor(x => x.MarkId).NotEqual(Guid.Empty);
            RuleFor(x => x.GroupMemberId).NotEqual(Guid.Empty);
            RuleFor(x => x.DepartmentMemberId).NotEqual(Guid.Empty);
        }
    }
}
