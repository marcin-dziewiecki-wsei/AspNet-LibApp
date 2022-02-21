using AutoMapper;
using LibApp.Domain.Dtos.Genre;
using LibApp.Domain.Models;

namespace LibApp.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();
        }
    }
}
