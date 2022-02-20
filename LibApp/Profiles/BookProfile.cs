using AutoMapper;
using LibApp.Domain.Dtos.Book;
using LibApp.Domain.Models;

namespace LibApp.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(x => x.Genre, z => z.MapFrom(x => x.Genre.Name));

            CreateMap<Book, BookDetailsDto>()
                .ForMember(x => x.Genre, z => z.MapFrom(x => x.Genre.Name));

            CreateMap<NewBookDto, Book>();

            CreateMap<UpdateBookDto, Book>();
        }
    }
}
