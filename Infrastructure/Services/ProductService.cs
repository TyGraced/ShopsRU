using Core.Dtos.V1.Request;
using Core.Dtos.V1.Response;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<Product>> CreateProductAsync(CreateProductDto model)
        {
            var products = await _context.Products.SingleOrDefaultAsync(p => p.Name == model.Name);
            
            if (products != null)
            {
                return new ApiResponse<Product>
                {
                    Message = "This product already exist",
                    Status = false,
                    Data = null
                };
            }

            var newProduct = new Product
            {
                Name = model.Name,
                Price = model.Price,
                IsGrocery = model.IsGrocery
            };

            await _context.Products.AddAsync(newProduct);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new ApiResponse<Product>
                {
                    Message = "Successful",
                    Status = true,
                    Data = newProduct
                };
            }

            return new ApiResponse<Product>
            {
                Message = "An error has occurred, try again",
                Status = false,
                Data = null
            };
        }

        public async Task<ApiResponse<IReadOnlyList<Product>>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();

            if (products.Count == 0)
            {
                return new ApiResponse<IReadOnlyList<Product>>
                {
                    Message = "No products available",
                    Status = true,
                    Data = products
                };
            }
            return new ApiResponse<IReadOnlyList<Product>>
            {
                Message = "Successful",
                Status = true,
                Data = products
            };
        }

        public async Task<ApiResponse<Product>> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                return new ApiResponse<Product>
                {
                    Message = "Successful",
                    Status = true,
                    Data = product
                };
            }
            return new ApiResponse<Product>
            {
                Message = "Product does not exist",
                Status = false,
                Data = null
            };
        }

        public async Task<ApiResponse<Product>> GetProductByNameAsync(string productName)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Name.ToLower() == productName.ToLower());

            if (product != null)
            {
                return new ApiResponse<Product>
                {
                    Message = "Successful",
                    Status = true,
                    Data = product
                };
            }
            return new ApiResponse<Product>
            {
                Message = "Product does not exist",
                Status = false,
                Data = null
            };
        }
    }
}
