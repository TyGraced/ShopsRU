using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _repo;
        public CustomerController(ICustomerService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomers()
        {
            var customers = await _repo.GetCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            return await _repo.GetCustomerByIdAsync(id);
        }

        [HttpGet("/getbyname/{name}")]
        public async Task<ActionResult<Customer>> GetCustomerByName(string name)
        {
            return await _repo.GetCustomerByNameAsync(name);
        }
    }
}