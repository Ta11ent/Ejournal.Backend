namespace Enews.WebApi.Models
{
    public class GetNewsListDto : IMapWith<GetNewsLookup>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetNewsListDto, GetNewsLookup>()
                .ForMember(dto => dto.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForMember(dto => dto.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize));
        }
    }
}
