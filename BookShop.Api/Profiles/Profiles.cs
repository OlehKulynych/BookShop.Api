using AutoMapper;
using BookShop.Api.Models;
using BookShop.Shared.DTO;

namespace BookShop.Api.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<BookCategory, BookCategoryDto>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)).ReverseMap();
            CreateMap<BookCategory, BookCategoryAddDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)).ReverseMap();
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.BookCategoryName,
                opt => opt.MapFrom(src => src.BookCategory.Name)).ReverseMap();
            CreateMap<BookAddDto, Book>().ReverseMap();
          
            CreateMap<User, RegisterUserDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => src.Surname))
                .ForMember(
                dest => dest.EmailAddress,
                opt => opt.MapFrom(src => src.Email))
                .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.PasswordHash));
            CreateMap<RegisterUserDto, User>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => src.Surname))
                .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(
                dest => dest.PasswordHash,
                opt => opt.MapFrom(src => src.Password))
                .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => src.EmailAddress));
            CreateMap<User, UserDto>()
               .ForMember(
               dest => dest.Name,
               opt => opt.MapFrom(src => src.Name))
               .ForMember(
               dest => dest.Surname,
               opt => opt.MapFrom(src => src.Surname))
               .ForMember(
               dest => dest.EmailAddress,
               opt => opt.MapFrom(src => src.Email));
            CreateMap<OrderDto, Order>()
               .ForMember(
                dest => dest.EmailClient,
                opt => opt.MapFrom(src => src.EmailClient))
               .ForMember(
                dest => dest.NameClient,
                opt => opt.MapFrom(src => src.NameClient))
               .ForMember(
                dest => dest.SurnameClient,
                opt => opt.MapFrom(src => src.SurnameClient))
               .ForMember(
                dest => dest.AddressClient,
                opt => opt.MapFrom(src => src.AddressClient))
               .ForMember(
                dest => dest.PhoneClient,
                opt => opt.MapFrom(src => src.PhoneClient));
            CreateMap<OrderDetailDto, OrderDetail>()
               .ForMember(
                dest => dest.BookId,
                opt => opt.MapFrom(src => src.BookId))
               .ForMember(
                dest => dest.Quantity,
                opt => opt.MapFrom(src => src.Quantity));
        }
    }

}

