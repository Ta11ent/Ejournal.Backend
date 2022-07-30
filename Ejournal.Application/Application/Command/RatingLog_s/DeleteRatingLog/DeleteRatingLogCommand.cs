using MediatR;
using System;

namespace Ejournal.Application.Application.Command.RatingLog_s.DeleteRatingLog
{
    public class DeleteRatingLogCommand : IRequest
    {
        public Guid RatingLogId { get; set; }
    }
}
