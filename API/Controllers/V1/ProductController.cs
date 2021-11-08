using Core.Dtos.V1;
using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.V1
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _repo;

        public ProductController(IProductService repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Creates Products
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Products.Create)]
        public async Task<ActionResult<ApiResponse<ProductResponseDto>>> CreateProductAsync([FromBody] CreateProductDto model)
        {
            var result = await _repo.CreateProductAsync(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Products.GetAll)]
        public async Task<ActionResult<ApiResponse<ProductResponseDto>>> GetAllProducts()
        {
            var products = await _repo.GetAllProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Gets product by ProductId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Products.GetById)]
        public async Task<ActionResult<ApiResponse<ProductResponseDto>>> GetProductByIdAsync([FromRoute] int productId)
        {
            var product = await _repo.GetProductByIdAsync(productId);
            if (product.Status)
            {
                return Ok(product);
            }
            return BadRequest(product);
        }

        /// <summary>
        /// Gets product by name
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Products.GetByName)]
        public async Task<ActionResult<ApiResponse<ProductResponseDto>>> GetProductByName([FromRoute] string productName)
        {
            var product = await _repo.GetProductByNameAsync(productName);
            if (product.Status)
            {
                return Ok(product);
            }
            return BadRequest(product);
        }
    }
}
