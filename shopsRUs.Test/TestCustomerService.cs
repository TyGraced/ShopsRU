using Core.Dtos.V1.Request;
using Core.Entities;
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
    public class TestCustomerService
    {
        [Fact]
        public async Task CustomerService_GetAllCustomers_GivenTheyExist()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("Gets_all").Options;

            using var context = new AppDbContext(options);

            var sut = new CustomerService(context);

            await sut.CreateCustomerAsync(new CreateCustomerDto { Name = "Bob" });
            await sut.CreateCustomerAsync(new CreateCustomerDto { Name = "Luke" });

            var allCustomers = await sut.GetCustomersAsync();

            allCustomers.Data.Count.Should().Be(2);
        }

        [Fact]
        public async Task CustomerService_CreateCustomer_GivenNewCustomerObject()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("Writes_to_Db").Options;

            using var context = new AppDbContext(options);

            var sut = new CustomerService(context);

            await sut.CreateCustomerAsync(new CreateCustomerDto { Name = "Bola" });
            context.Customers.Single().Name.Should().Be("Bola");
        }

    }
}
