using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using Ejournal.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Ejournal.Persistence
{
    public class EjournalDbContext : DbContext, IEjournalDbContext
    {
        #region DbSet
        public DbSet<Course> Courses { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<CurriculumPart> CurriculumParts { get; set; }
        public DbSet<CurriculumPartSubject> CurriculumPartSubjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentMember> DepartmentMembers { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<RatingLog> RaitingLogs { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleDay> ScheduleDays { get; set; }
        public DbSet<ScheduleSubject> ScheduleSubjects { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<StudentGroupMember> StudentGroupMembers { get; set; }
        public DbSet<StudyYear> StudyYears { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        public EjournalDbContext(DbContextOptions<EjournalDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region builder.ApplyConfiguration
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new CurriculumConfiguration());
            builder.ApplyConfiguration(new CurriculumPartConfiguration());
            builder.ApplyConfiguration(new CurriculumPartSubjectConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new DepartmentMemberConfiguration());
            builder.ApplyConfiguration(new HomeWorkConfiguration());
            builder.ApplyConfiguration(new MarkConfigaration());
            builder.ApplyConfiguration(new PartConfiguration());
            builder.ApplyConfiguration(new RaitingLogConfiguration());
            builder.ApplyConfiguration(new ScheduleConfiguration());
            builder.ApplyConfiguration(new ScheduleDayConfiguration());
            builder.ApplyConfiguration(new ScheduleSubjectConfiguration());
            builder.ApplyConfiguration(new SpecializationConfiguration());
            builder.ApplyConfiguration(new SpecializationConfiguration());
            builder.ApplyConfiguration(new StudentGroupConfiguration());
            builder.ApplyConfiguration(new StudentGroupMemberConfiguration());
            builder.ApplyConfiguration(new StudyYearConfiguration());
            builder.ApplyConfiguration(new SubjectConfiguration());
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
