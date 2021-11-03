using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        public CustomerService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> GetCustomerByNameAsync(string name)
        {
            return await _context.Customers.FirstOrDefaultAsync(n => n.FirstName == name);
        }

        public async Task<IReadOnlyList<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}