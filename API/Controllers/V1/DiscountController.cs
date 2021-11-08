using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos.V1;
using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _repo;
        public DiscountController(IDiscountService repo)
        {
            _repo = repo;

        }

        /// <summary>
        /// Creates discounts
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Discounts.Create)]
        public async Task<ActionResult<ApiResponse<DiscountResponseDto>>> CreateDiscount([FromBody] DiscountDto model)
        {
            var result = await _repo.CreateDiscountAsync(model);

            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Gets all discounts
        /// </summary>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Discounts.GetAll)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<DiscountResponseDto>>>> GetAllDiscount()
        {
            var result = await _repo.GetAllDiscountsAsync();

            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Gets discounts by type
        /// </summary>
        /// <param name="discountType"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Discounts.GetByType)]
        public async Task<ActionResult<ApiResponse<DiscountResponseDto>>> GetDiscountByType([FromRoute] string discountType)
        {
            var result = await _repo.GetDiscountByTypeAsync(discountType);

            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}