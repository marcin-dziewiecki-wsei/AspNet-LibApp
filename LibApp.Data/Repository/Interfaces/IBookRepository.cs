using LibApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibApp.Data.Repository.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<Book> GetByIdWithGenreAsync(int id);
        Task<IList<Book>> GetAllByIdsWithGenreAsync(List<int> ids);
        Task<IList<Book>> GetAllAvailableBooksWithGenreFilteredByNameAsync(string name);
    }
}
