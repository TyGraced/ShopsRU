using System.Threading.Tasks;
using Core.Dtos.V1;
using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _repo;
        public InvoiceController(IInvoiceService repo)
        {
            _repo = repo;

        }

        /// <summary>
        /// Gets the total invoice amount from all the customer purchases after deducting discounts.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Invoice.Get)]
        public async Task<ActionResult<ApiResponse<InvoiceTotalAmountResponseDto>>> GetTotalInvoiceAmount( [FromBody] CreateInvoiceDto model)
        {
            var result = await _repo.GetTotalInvoiceAmountAsync(model);

            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}