using AutoMapper;
using Ejournal.Application.Application.Command.ScheduleSubject_s.UpdateScheduleSubject;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Schedule
{
    public class UpdateScheduleSubjectDto : IMapWith<UpdateScheduleSubjectCommand>
    {
        public int Order { get; set; }
        public bool Active { get; set; }
        public Guid SubjectId { get; set; }
        public Guid? MembershipId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateScheduleSubjectDto, UpdateScheduleSubjectCommand>()
                .ForMember(entityDto => entityDto.Order,
                    opt => opt.MapFrom(entity => entity.Order))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active))
                .ForMember(entityDto => entityDto.SubjectId,
                    opt => opt.MapFrom(entity => entity.SubjectId))
                .ForMember(entityDto => entityDto.DepartmentMemberId,
                    opt => opt.MapFrom(entity => entity.MembershipId));
        }
    }
}
