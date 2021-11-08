using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;
using Core.Dtos.V1.Response;
using Core.Dtos.V1.Request;

namespace Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        public CustomerService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ApiResponse<Customer>> CreateCustomerAsync(CreateCustomerDto model)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Name == model.Name);

            if (customer != null)
            {
                return new ApiResponse<Customer>
                {
                    Message = "This name already exists",
                    Status = false,
                    Data = null
                };
            }

            var newCustomer = new Customer
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                IsAffiliate = model.IsAffiliate,
                IsEmployee = model.IsEmployee,
                CreatedOn = model.CreatedOn 
            };

            await _context.Customers.AddAsync(newCustomer);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new ApiResponse<Customer>
                {
                    Message = "Successful",
                    Status = true,
                    Data = newCustomer
                };
            }
            return new ApiResponse<Customer>
            {
                Message = "An error has occurred, try again",
                Status = false,
                Data = null
            };
        }

        public async Task<ApiResponse<Customer>> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == customerId);
            if (customer != null)
            {
                return new ApiResponse<Customer>
                {
                    Message = "Successful",
                    Status = true,
                    Data = customer
                };
            }
            return new ApiResponse<Customer>
            {
                Message = "customer does not exist",
                Status = false,
                Data = null
            };
        }

        public async Task<ApiResponse<Customer>> GetCustomerByNameAsync(string name)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

            if (customer != null)
            {
                return new ApiResponse<Customer>
                {
                    Message = "Successful",
                    Status = true,
                    Data = customer
                };
            }
            return new ApiResponse<Customer>
            {
                Message = "customer does not exist",
                Status = false,
                Data = null
            };
        }

        public async Task<ApiResponse<IReadOnlyList<Customer>>> GetCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();

            if (customers.Count == 0)
            {
                return new ApiResponse<IReadOnlyList<Customer>>
                {
                    Message = "No customers available",
                    Status = true,
                    Data = customers
                };
            }
            return new ApiResponse<IReadOnlyList<Customer>>
            {
                Message = "Successful",
                Status = true,
                Data = customers
            };
        }
    }
}