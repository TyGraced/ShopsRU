using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse<Product>> CreateProductAsync(CreateProductDto model);
        Task<ApiResponse<Product>> GetProductByIdAsync(int id);
        Task<ApiResponse<Product>> GetProductByNameAsync(string name);
        Task<ApiResponse<IReadOnlyList<Product>>> GetAllProductsAsync();
    }
}
