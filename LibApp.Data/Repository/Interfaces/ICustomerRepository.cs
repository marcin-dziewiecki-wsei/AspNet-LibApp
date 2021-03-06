using LibApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibApp.Data.Repository.Interfaces
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Task<Customer> GetByIdWithMemberTypeAsync(int id);
        Task<IList<Customer>> GetAllFilteredByNameWithMembershipTypesAsync(string name);
    }
}
