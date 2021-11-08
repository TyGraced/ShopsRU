using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly AppDbContext _context;
        public InvoiceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<InvoiceTotalAmountResponseDto>> GetTotalInvoiceAmountAsync(CreateInvoiceDto model)
        {
            List<InvoiceCustomerDto> customers = new List<InvoiceCustomerDto>();
            List<InvoiceTotalDto> products = new List<InvoiceTotalDto>();

            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == model.ProductId);
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == model.CustomerId);

            if (product == null)
            {
                return new ApiResponse<InvoiceTotalAmountResponseDto>
                {
                    Message = "Error! Please ensure you've filled in a valid ProductId",
                    Status = false,
                    Data = null
                };
            }

            if (customer == null)
            {
                return new ApiResponse<InvoiceTotalAmountResponseDto>
                {
                    Message = "Error! Please ensure you've filled in a valid CustomerId",
                    Status = false,
                    Data = null
                };
            }

            var diffInYears = DateTimeOffset.Now.ToUnixTimeSeconds() - DateTimeOffset.Parse(customer.CreatedOn.ToString()).ToUnixTimeSeconds();
            var customerYears = (int)(diffInYears / 31536000);

            customers.Add(new InvoiceCustomerDto { IsAffiliate = customer.IsAffiliate, IsEmployee = customer.IsEmployee, OverTwoYears = customerYears });
            products.Add(new InvoiceTotalDto { Price = product.Price * model.Count, IsGroceries = product.IsGrocery });

            var isAffiliate = customer.IsAffiliate;
            var isEmployee = customer.IsEmployee;


            decimal percentageDiscountPrice = products.Where(p => !p.IsGroceries).Sum(s => s.Price);
            var nonPercentageDiscountPrice = products.Where(x => x.IsGroceries).Sum(x => x.Price);

            if (isAffiliate && isEmployee && customerYears >= 2 && percentageDiscountPrice > 0)
            {
                var discountedPrice = percentageDiscountPrice - (percentageDiscountPrice * 30 / 100);
                var totalPrice = nonPercentageDiscountPrice + discountedPrice;
                int discountPerHundereds = ((int)(percentageDiscountPrice / 100) * 5);
                var totalAmount = totalPrice - discountPerHundereds;
                return new ApiResponse<InvoiceTotalAmountResponseDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new InvoiceTotalAmountResponseDto { TotalAmount = totalAmount }
                };
            }

            if (isAffiliate && isEmployee && percentageDiscountPrice > 0)
            {
                var discountedPrice = percentageDiscountPrice - (percentageDiscountPrice * 30 / 100);
                var totalPrice = nonPercentageDiscountPrice + discountedPrice;
                int discountPerHundereds = ((int)(percentageDiscountPrice / 100) * 5);
                var totalAmount = totalPrice - discountPerHundereds;
                return new ApiResponse<InvoiceTotalAmountResponseDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new InvoiceTotalAmountResponseDto { TotalAmount = totalAmount }
                };
            }

            if (isAffiliate && customerYears >= 2 && percentageDiscountPrice > 0)
            {
                var discountedPrice = percentageDiscountPrice - (percentageDiscountPrice * 10 / 100);
                var totalPrice = nonPercentageDiscountPrice + discountedPrice;
                int discountPerHundereds = ((int)(percentageDiscountPrice / 100) * 5);
                var totalAmount = totalPrice - discountPerHundereds;
                return new ApiResponse<InvoiceTotalAmountResponseDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new InvoiceTotalAmountResponseDto { TotalAmount = totalAmount }
                };
            }

            if (isEmployee && customerYears >= 2 && percentageDiscountPrice > 0)
            {
                var discountedPrice = percentageDiscountPrice - (percentageDiscountPrice * 30 / 100);
                var totalPrice = nonPercentageDiscountPrice + discountedPrice;
                int discountPerHundereds = ((int)(percentageDiscountPrice / 100) * 5);
                var totalAmount = totalPrice - discountPerHundereds;
                return new ApiResponse<InvoiceTotalAmountResponseDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new InvoiceTotalAmountResponseDto { TotalAmount = totalAmount }
                };
            }

            if (isAffiliate && percentageDiscountPrice > 0)
            {

                var discountedPrice = percentageDiscountPrice - (percentageDiscountPrice * 10 / 100);
                var totalPrice = nonPercentageDiscountPrice + discountedPrice;
                int discountPerHundereds = ((int)(percentageDiscountPrice / 100) * 5);
                var totalAmount = totalPrice - discountPerHundereds;
                return new ApiResponse<InvoiceTotalAmountResponseDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new InvoiceTotalAmountResponseDto { TotalAmount = totalAmount }
                };
            }

            if (isEmployee && percentageDiscountPrice > 0)
            {

                var discountedPrice = percentageDiscountPrice - (percentageDiscountPrice * 30 / 100);
                var totalPrice = nonPercentageDiscountPrice + discountedPrice;
                int discountPerHundereds = ((int)(percentageDiscountPrice / 100) * 5);
                var totalAmount = totalPrice - discountPerHundereds;
                return new ApiResponse<InvoiceTotalAmountResponseDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new InvoiceTotalAmountResponseDto { TotalAmount = totalAmount }
                };
            }

            if (customerYears >= 2 && percentageDiscountPrice > 0)
            {

                var discountedPrice = percentageDiscountPrice - (percentageDiscountPrice * 5 / 100);
                var totalPrice = nonPercentageDiscountPrice + discountedPrice;
                int discountPerHundereds = ((int)(percentageDiscountPrice / 100) * 5);
                var totalAmount = totalPrice - discountPerHundereds;
                return new ApiResponse<InvoiceTotalAmountResponseDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new InvoiceTotalAmountResponseDto { TotalAmount = totalAmount }
                };
            }


            else
            {

                var totalPrice = nonPercentageDiscountPrice + percentageDiscountPrice;
                int discountPerHundereds = ((int)(nonPercentageDiscountPrice / 100) * 5);
                var totalAmount = totalPrice - discountPerHundereds;
                return new ApiResponse<InvoiceTotalAmountResponseDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new InvoiceTotalAmountResponseDto { TotalAmount = totalAmount }
                };
            }

        }
    }
}
