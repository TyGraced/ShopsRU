using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IInvoiceService
    {
        Task<ApiResponse<InvoiceTotalAmountResponseDto>> GetTotalInvoiceAmountAsync (CreateInvoiceDto model);   
    }
}