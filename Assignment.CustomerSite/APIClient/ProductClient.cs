using System;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Json;
using Assignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.CustomerSite.APIClient;

namespace Assignment.CustomerSite
{
    public class ProductClient:IProductClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IList<Products>> GetProducts()
        {
            var httpClient = _httpClientFactory.CreateClient("local");
            var response = await httpClient.GetAsync("api/brands");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IList<Products>>();
        }
    }
}
