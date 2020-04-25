using AutoMapper;
using CoreCodeCamp.Model;

namespace CoreCodeCamp.Data
{
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            CreateMap<Camp, CampModel>()
                .ForMember(f => f.Venue, o => o.MapFrom(s => s.Location.VenueName))
                .ReverseMap();
            CreateMap<Talk, TalkModel>()
                .ReverseMap()
                .ForMember(t => t.Camp, opt => opt.Ignore())
                .ForMember(t => t.Speaker, opt => opt.Ignore());
            CreateMap<Speaker, SpeakerModel>()
                .ReverseMap();
        }
    }
}