using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Interfaces
{
    public interface IEjournalDbContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Curriculum> Curriculums { get; set; }
        DbSet<CurriculumPart> CurriculumParts { get; set; }
        DbSet<CurriculumPartSubject> CurriculumPartSubjects { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<DepartmentMember> DepartmentMembers { get; set; }
        DbSet<HomeWork> HomeWorks { get; set; }
        DbSet<Mark> Marks { get; set; }
        DbSet<Part> Parts { get; set; }
        DbSet<RatingLog> RaitingLogs { get; set; }
        DbSet<Schedule> Schedules { get; set; }
        DbSet<ScheduleDay> ScheduleDays { get; set; }
        DbSet<ScheduleSubject> ScheduleSubjects { get; set; }
        DbSet<Specialization> Specializations { get; set; }
        DbSet<StudentGroup> StudentGroups { get; set; }
        DbSet<StudentGroupMember> StudentGroupMembers { get; set; }
        DbSet<StudyYear> StudyYears { get; set; }
        DbSet<Subject> Subjects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}