using AutoMapper;
using BookShop.Api.Models;
using BookShop.DTO.DTO;

namespace BookShop.Api.Profiles
{
    public class Profiles: Profile
    {
        public Profiles()
        {
            CreateMap<BookCategory, BookCategoryDTO>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)).ReverseMap();
        }

    }
}
