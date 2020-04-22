using AutoMapper;
using CoreCodeCamp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            CreateMap<Camp, CampModel>()
                .ForMember(f => f.Venue, o => o.MapFrom(s => s.Location.VenueName));
            CreateMap<Talk, TalkModel>();
            CreateMap<Speaker, SpeakerModel>();
        }
    }
}