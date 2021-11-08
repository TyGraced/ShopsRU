using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly AppDbContext _context;
        public DiscountService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<ApiResponse<Discount>> CreateDiscountAsync(DiscountDto model)
        {
            var check = await _context.Discounts.SingleOrDefaultAsync(x => x.DiscountType == model.DiscountType);
            if (check is not null)
            {
                return new ApiResponse<Discount>
                {
                    Message = "Discount type already exist",
                    Status = false,
                    Data = null
                };
            }
            var discount = new Discount
            {
                PercentageDiscount = model.PercentageDiscount,
                CreatedOn = DateTime.Now,
                DiscountType = model.DiscountType
            };

            await _context.Discounts.AddAsync(discount);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new ApiResponse<Discount>
                {
                    Message = "Successful",
                    Status = true,
                    Data = discount
                };
            }
            return new ApiResponse<Discount>
            {
                Message = "An error has occurred, try again",
                Status = false,
                Data = null
            };
        }

        public async Task<ApiResponse<IReadOnlyList<Discount>>> GetAllDiscountsAsync()
        {
            var discounts = await _context.Discounts.ToListAsync();

            if (discounts.Count == 0)
            {
                return new ApiResponse<IReadOnlyList<Discount>>
                {
                    Message = "No discounts available",
                    Status = true,
                    Data = discounts
                };
            }
            return new ApiResponse<IReadOnlyList<Discount>>
            {
                Message = "Successsful",
                Status = true,
                Data = discounts
            };
        }

        public async Task<ApiResponse<Discount>> GetDiscountByTypeAsync(string discountType)
        {
            var discount = await _context.Discounts.SingleOrDefaultAsync(x => x.DiscountType.ToLower() == discountType.ToLower());

            if (discount != null)
            {
                return new ApiResponse<Discount>
                {
                    Message = "Successful",
                    Status = true,
                    Data = discount
                };
            }
            return new ApiResponse<Discount>
            {
                Message = "discount does not exist",
                Status = false,
                Data = null
            };
        }
    }
}