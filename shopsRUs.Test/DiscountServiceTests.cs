using Core.Dtos.V1.Request;
using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace shopsRUs.Test
{
    public class DiscountServiceTests
    {
        [Fact]
        public async Task DiscountService_GetAllDiscount_GivenTheyExist()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("Gets_all_discount").Options;

            using var context = new AppDbContext(options);

            var sut = new DiscountService(context);

            await sut.CreateDiscountAsync(new DiscountDto { PercentageDiscount = 30, DiscountType = "Employee" });
            await sut.CreateDiscountAsync(new DiscountDto { PercentageDiscount = 10, DiscountType = "Affiliate" });
            await sut.CreateDiscountAsync(new DiscountDto { PercentageDiscount = 5, DiscountType = "PerHundred" });

            var allDiscounts = await sut.GetAllDiscountsAsync();

            allDiscounts.Data.Count.Should().Be(3);
        }

        [Fact]
        public async Task DiscountService_CreateDiscount_GivenNewDiscountObject()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("Creates_discount_in_Db").Options;

            using var context = new AppDbContext(options);

            var sut = new DiscountService(context);

            await sut.CreateDiscountAsync(new DiscountDto { DiscountType = "Affiliate" });
            context.Discounts.Single().DiscountType.Should().Be("Affiliate");
        }

    }
}
