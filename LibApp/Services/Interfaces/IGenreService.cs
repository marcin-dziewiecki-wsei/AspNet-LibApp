using LibApp.Domain.Dtos.Genre;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibApp.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IList<GenreDto>> GetAll();
    }
}
