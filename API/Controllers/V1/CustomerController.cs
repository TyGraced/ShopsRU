using System.Threading.Tasks;
using API.Dtos.V1.Response;
using Core.Dtos.V1;
using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _repo;
        public CustomerController(ICustomerService repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Creates Customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Customers.Create)]
        public async Task<ActionResult<ApiResponse<CustomerResponseDto>>> CreateCustomerAsync([FromBody] CreateCustomerDto model)
        {
            var result = await _repo.CreateCustomerAsync(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Customers.GetAll)]
        public async Task<ActionResult<ApiResponse<CustomerResponseDto>>> GetCustomers()
        {
            var customers = await _repo.GetCustomersAsync();
            return Ok(customers);
        }

        /// <summary>
        /// Gets customer by customerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Customers.GetById)]
        public async Task<ActionResult<ApiResponse<CustomerResponseDto>>> GetCustomerById([FromRoute] int customerId)
        {
            var customer = await _repo.GetCustomerByIdAsync(customerId);
            if (customer.Status)
            {
                return Ok(customer);
            }
            return BadRequest(customer);
        }

        /// <summary>
        /// Gets customer by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Customers.GetByName)]
        public async Task<ActionResult<ApiResponse<CustomerResponseDto>>> GetCustomerByName([FromRoute] string name)
        {
            var result = await _repo.GetCustomerByNameAsync(name);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}