using API;
using Core.Dtos.V1;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace shopsRUs.Test
{
    public class ProductTest
    {
        private readonly HttpClient _client;

        public ProductTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task ProductController_GetProduct_GivenId()
        {
            var response = await _client.GetAsync(ApiRoutes.Products.GetById.Replace("{productId}", "1"));
        }
    }
}
