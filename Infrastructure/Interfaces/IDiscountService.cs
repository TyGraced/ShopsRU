using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using Core.Entities;

namespace Infrastructure.Interfaces
{
    public interface IDiscountService
    {
        Task<ApiResponse<Discount>> CreateDiscountAsync(DiscountDto model);
      
        Task<ApiResponse<Discount>> GetDiscountByTypeAsync(string type);
        Task<ApiResponse<IReadOnlyList<Discount>>> GetAllDiscountsAsync();    
    }
}