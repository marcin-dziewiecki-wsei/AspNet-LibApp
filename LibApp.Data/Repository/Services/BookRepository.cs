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

        public async Task<Book> GetByIdWithGenreAsync(int id)
            => await context.Books.Include(x => x.Genre).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IList<Book>> GetAllByIdsWithGenreAsync(List<int> ids)
            => await GetAllQuery<Book>().Include(x => x.Genre).Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task<IList<Book>> GetAllAvailableBooksWithGenreFilteredByNameAsync(string name)
            => await GetAllFilteredByNameQuery<Book>(name)
                        .Include(x => x.Genre)
                        .Where(x => x.NumberAvailable > 0)
                        .ToListAsync();

        public override Task<int> AddAsync(Book entity)
        {
            entity.DateAdded = System.DateTime.Now;
            entity.NumberAvailable = entity.NumberInStock;

            return base.AddAsync(entity);
        }

        public override async Task<bool> UpdateAsync(Book entity)
        {
            var bookFromDb = await GetByIdAsync(entity.Id, noTracking: true);

            if (bookFromDb is null)
                return false;

            var stockDiff = entity.NumberInStock - bookFromDb.NumberInStock;

            entity.DateAdded = bookFromDb.DateAdded;
            entity.NumberAvailable = bookFromDb.NumberAvailable + stockDiff;

            await UpdateEntityAsync(entity);
            return true;
        }
    }
}
