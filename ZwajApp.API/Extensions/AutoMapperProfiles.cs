using System.Linq;
using AutoMapper;
using ZwajApp.API.DTOs;
using ZwajApp.API.Models;

namespace ZwajApp.API.Extensions
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDTO>()
            .ForMember(dest=>dest.PhotoUrl , opt=>{
                opt.MapFrom(src=>src.Photos.FirstOrDefault(pho=>pho.IsMain));
            });
            CreateMap<User,UserForDetailsDTO>().ForMember(dest=>dest.PhotoUrl , opt=>{
                opt.MapFrom(src=>src.Photos.FirstOrDefault(pho=>pho.IsMain));
            });
            CreateMap<Photo,PhotoForDetailsDTO>();
        }
    }
}