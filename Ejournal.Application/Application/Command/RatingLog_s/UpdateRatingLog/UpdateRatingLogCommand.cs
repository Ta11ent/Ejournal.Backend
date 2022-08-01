using MediatR;
using System;

namespace Ejournal.Application.Application.Command.RatingLog_s.UpdateRatingLog
{
    public class UpdateRatingLogCommand : IRequest
    {
        public Guid RatingLogId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid SubjectId { get; set; }
        public Guid MarkId { get; set; }
        public Guid DepartmentMemberId { get; set; }
    }
}
