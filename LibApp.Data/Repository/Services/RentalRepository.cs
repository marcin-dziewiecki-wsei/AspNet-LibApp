using LibApp.Data.Data;
using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Models;
using System.Threading.Tasks;

namespace LibApp.Data.Repository.Services
{
    internal class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<bool> UpdateAsync(Rental entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
