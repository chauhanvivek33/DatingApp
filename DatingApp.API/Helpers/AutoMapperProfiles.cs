using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoURl, opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); })
                .ForMember(dest => dest.Age,x=>x.MapFrom(src=>src.DateOfBirth.GetUsersAge()));
            CreateMap<User, UserForListDto>()
             .ForMember(dest => dest.PhotoURl, opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); })
             .ForMember(dest => dest.Age, x => x.MapFrom(src => src.DateOfBirth.GetUsersAge()));
            CreateMap<Photo, PhotoForDetailDto>();
        }
    }
}
