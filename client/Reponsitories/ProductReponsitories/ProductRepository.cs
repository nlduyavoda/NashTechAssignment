using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LibraryShare.Product;

namespace backend.Reponsitories.ProductReponsitories
{
  public class ProductRepository : IProduct
  {
    HttpClient _client;
    public ProductRepository(HttpClient client)
    {
      _client = client;
    }

    public async Task<ProductVM> GetProductById(int id)
    {
      var res = await _client.GetAsync($"api/product/{id}");
      res.EnsureSuccessStatusCode();
      var product = await res.Content.ReadAsAsync<ProductVM>();
      return product;
    }
  }
}