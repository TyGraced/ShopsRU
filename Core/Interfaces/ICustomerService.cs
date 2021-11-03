using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICustomerService
    {
         Task<Customer> GetCustomerByIdAsync(int id);
         Task<Customer> GetCustomerByNameAsync(string name);
         Task<IReadOnlyList<Customer>> GetCustomersAsync();
    }
}