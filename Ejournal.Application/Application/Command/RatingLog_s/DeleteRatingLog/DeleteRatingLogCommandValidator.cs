using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.RatingLog_s.DeleteRatingLog
{
    public class DeleteRatingLogCommandValidator : AbstractValidator<DeleteRatingLogCommand>
    {
        public DeleteRatingLogCommandValidator()
        {
            RuleFor(x => x.RatingLogId).NotEqual(Guid.Empty);
        }
    }
}
