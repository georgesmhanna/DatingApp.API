using System.Linq;
using AutoMapper;
using DatingApp.API.Controllers.DTOs;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opts =>
            {
                opts.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
            .ForMember(dest => dest.Age, opts => {
                opts.ResolveUsing(src => src.DateOfBirth.GetAgeFromDateOfBirth());
            });
            CreateMap<User, UserForDetailedDto>()
            .ForMember(dest => dest.PhotoUrl, opts =>
            {
                opts.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            })
                .ForMember(dest => dest.Age, opts => {
                opts.ResolveUsing(src => src.DateOfBirth.GetAgeFromDateOfBirth());
            });
            CreateMap<Photo, PhotoForDetailedDto>();
        }
    }
}