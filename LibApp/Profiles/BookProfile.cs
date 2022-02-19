using AutoMapper;
using LibApp.Domain.Dtos;
using LibApp.Domain.Models;

namespace LibApp.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
