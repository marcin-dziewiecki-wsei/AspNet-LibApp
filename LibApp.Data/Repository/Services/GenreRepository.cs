using LibApp.Data.Data;
using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Models;
using System;
using System.Threading.Tasks;

namespace LibApp.Data.Repository.Services
{
    internal class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<bool> UpdateAsync(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
