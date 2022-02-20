using LibApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibApp.Data.Repository.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<IList<Book>> GetAllAvailableBooksFilteredByNameAsync(string name);
    }
}
