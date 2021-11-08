using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using Core.Entities;

namespace Infrastructure.Interfaces
{
    public interface ICustomerService
    {

        Task<ApiResponse<Customer>> CreateCustomerAsync(CreateCustomerDto model);
        Task<ApiResponse<Customer>> GetCustomerByIdAsync(int id);
        Task<ApiResponse<Customer>> GetCustomerByNameAsync(string name);
        Task<ApiResponse<IReadOnlyList<Customer>>> GetCustomersAsync();
    }
}
