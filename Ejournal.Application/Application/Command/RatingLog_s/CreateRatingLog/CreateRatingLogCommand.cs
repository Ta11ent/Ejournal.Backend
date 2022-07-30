using MediatR;
using System;

namespace Ejournal.Application.Application.Command.RatingLog_s.CreateRatingLog
{
    public class CreateRatingLogCommand : IRequest<Guid>
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid SubjectId { get; set; }
        public Guid MarkId { get; set; }
        public Guid StudentId { get; set; }
        public Guid ProfessorId { get; set; }
    }
}
