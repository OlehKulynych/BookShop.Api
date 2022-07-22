﻿using AutoMapper;
using BookShop.Api.Models;
using BookShop.Shared.DTO;

namespace BookShop.Api.Profiles
{
    public class Profiles: Profile
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
            CreateMap<BookCategory, BookCategoryAddDto>();
            CreateMap<Book, BookDto>()
                .ForMember(dest=>dest.BookCategoryName,
                opt => opt.MapFrom(src => src.BookCategory.Name)).ReverseMap();
            CreateMap<Book, BookAddDto>();
            CreateMap<CartItem, CartItemDto>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src=>src.Id))
                .ForMember(
                dest=>dest.BookId,
                opt => opt.MapFrom(src => src.BookId))
                .ForMember(
                dest => dest.CartId,
                opt => opt.MapFrom(src => src.CartId))
                .ForMember(
                dest => dest.BookName,
                opt => opt.MapFrom(src => src.Book.Name))
                .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Book.Description))
                .ForMember(
                dest => dest.ImageUrl,
                opt => opt.MapFrom(src=> src.Book.ImageUrl))
                .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Book.Price))
                .ForMember(
                dest => dest.Quantity,
                opt => opt.MapFrom(src => src.Quantity))
                .ForMember(
                dest => dest.TotalPrice,
                opt => opt.MapFrom(src => (src.Quantity*src.Book.Price)));
        }

    }
}