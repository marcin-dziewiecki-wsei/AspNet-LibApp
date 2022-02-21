using AutoMapper;
using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Dtos.Genre;
using LibApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Services
{
    internal class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }
        public async Task<IList<GenreDto>> GetAll()
        {
            var genres = await genreRepository.GetAllAsync();
            var response = genres.Select(x => mapper.Map<GenreDto>(x)).ToList();
            return response;
        }
    }
}
