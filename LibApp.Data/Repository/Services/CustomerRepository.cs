using LibApp.Data.Data;
using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibApp.Data.Repository.Services
{
    internal class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetByIdWithMemberTypeAsync(int id)
            => await context.Customers.Include(x => x.MembershipType).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IList<Customer>> GetAllFilteredByNameWithMembershipTypesAsync(string name)
            => await GetAllFilteredByNameQuery<Customer>(name).Include(x => x.MembershipType).ToListAsync();

        public override async Task<bool> UpdateAsync(Customer entity)
        {
            if (await context.Customers.AnyAsync(x => x.Id == entity.Id))
            {
                await UpdateEntityAsync(entity);
                return true;
            }

            return false;
        }
    }
}
