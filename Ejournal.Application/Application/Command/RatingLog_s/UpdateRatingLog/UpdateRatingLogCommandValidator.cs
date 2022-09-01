using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.RatingLog_s.UpdateRatingLog
{
    public class UpdateRatingLogCommandValidator : AbstractValidator<UpdateRatingLogCommand>
    {
        public UpdateRatingLogCommandValidator()
        {
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
            RuleFor(x => x.SubjectId).NotEqual(Guid.Empty);
            RuleFor(x => x.MarkId).NotEqual(Guid.Empty);
            RuleFor(x => x.DepartmentMemberId).NotEqual(Guid.Empty);
            RuleFor(x => x.RatingLogId).NotEqual(Guid.Empty);
        }
    }
}
