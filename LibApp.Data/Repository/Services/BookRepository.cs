using LibApp.Data.Data;
using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Data.Repository.Services
{
    internal class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IList<Book>> GetAllByIdsWithGenreAsync(List<int> ids)
            => await GetAllQuery<Book>().Include(x => x.Genre).Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task<IList<Book>> GetAllAvailableBooksFilteredByNameAsync(string name)
            => await GetAllFilteredByNameQuery<Book>(name)
                        .Where(x => x.NumberAvailable > 0)
                        .ToListAsync();

        public override Task<bool> UpdateAsync(Book entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
