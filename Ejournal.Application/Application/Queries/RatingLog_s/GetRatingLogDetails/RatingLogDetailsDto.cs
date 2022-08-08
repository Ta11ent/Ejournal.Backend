using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;


namespace Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogDetails
{
    public class RatingLogDetailsDto : IMapWith<RatingLog>
    {
        public Guid RatingLogId { get; set; }
        public DateTime Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string Subject { get; set; }
        public string Mark { get; set; }
        public StudentDto Student { get; set; } 
        public ProfessorDto Professor { get; set; }
        public  GroupDto Group {get;set;}

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RatingLog, RatingLogDetailsDto>()
                .ForMember(entityDto => entityDto.RatingLogId,
                    opt => opt.MapFrom(entiity => entiity.RaitingLogId))
                .ForMember(entityDto => entityDto.Date,
                    opt => opt.MapFrom(entiity => entiity.Date))
                .ForMember(entityDto => entityDto.DayOfWeek,
                    opt => opt.MapFrom(entiity => entiity.Date.DayOfWeek))
                .ForMember(entityDto => entityDto.Subject,
                    opt => opt.MapFrom(entiity => entiity.Subject.Name))
                .ForMember(entityDto => entityDto.Mark,
                    opt => opt.MapFrom(entiity => entiity.Mark.Name))
                .ForMember(entityDto => entityDto.Student,
                    opt => opt.MapFrom(entiity => entiity.StudentGroupMember))
                .ForMember(entityDto => entityDto.Professor,
                    opt => opt.MapFrom(entiity => entiity.DepartmentMember))
                 .ForMember(entityDto => entityDto.Group,
                    opt => opt.MapFrom(entiity => entiity.StudentGroupMember.StudentGroup));

        }

    }

    public class StudentDto : IMapWith<StudentGroupMember>
    {
        public Guid ClassMemberId { get; set; } 
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroupMember, StudentDto>()
                .ForMember(entityDto => entityDto.ClassMemberId,
                    opt => opt.MapFrom(entiity => entiity.StudentGroupMemberId))
                .ForMember(entityDto => entityDto.UserId,
                    opt => opt.MapFrom(entiity => entiity.UserId))
                .ForMember(entityDto => entityDto.FirstName,
                    opt => opt.MapFrom(entiity => entiity.User.FirstName))
                .ForMember(entityDto => entityDto.MiddleName,
                    opt => opt.MapFrom(entiity => entiity.User.MiddleName))
                .ForMember(entityDto => entityDto.LastName,
                    opt => opt.MapFrom(entiity => entiity.User.LastName));
        }
    }
    public class ProfessorDto : IMapWith<DepartmentMember>
    {
        public Guid MembershipId { get; set; } 
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentMember, ProfessorDto>()
                .ForMember(entityDto => entityDto.MembershipId,
                    opt => opt.MapFrom(entiity => entiity.DepartmentMemberId))
                .ForMember(entityDto => entityDto.UserId,
                    opt => opt.MapFrom(entiity => entiity.User.UserId))
                .ForMember(entityDto => entityDto.FirstName,
                    opt => opt.MapFrom(entiity => entiity.User.FirstName))
                .ForMember(entityDto => entityDto.MiddleName,
                    opt => opt.MapFrom(entiity => entiity.User.MiddleName))
                .ForMember(entityDto => entityDto.LastName,
                    opt => opt.MapFrom(entiity => entiity.User.LastName));
        }
    }
    public class GroupDto : IMapWith<StudentGroup>
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroup, GroupDto>()
                .ForMember(entityDto => entityDto.GroupId,
                    opt => opt.MapFrom(entity => entity.StudentGroupId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name));
        }
    }
}
