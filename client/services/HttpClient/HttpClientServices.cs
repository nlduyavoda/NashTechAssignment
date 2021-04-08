using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using client.Constatnts;
using LibraryShare.Categories;
using LibraryShare.Product;

namespace client.services.HttpClientService
{
  public class HttpClientServices : IHttpClientServices
  {
    private HttpClient _client;
    public HttpClientServices(HttpClient client)
    {
      _client = client;
    }

    public async Task<ProductVM> GetProductById(int id)
    {
      var res = await _client.GetAsync(Endpoints.ProductById(id));
      res.EnsureSuccessStatusCode();
      var product = await res.Content.ReadAsAsync<ProductVM>();
      return product;
    }

    public async Task<IEnumerable<ProductVM>> GetProducts()
    {
      var res = await _client.GetAsync(Endpoints.Product);
      res.EnsureSuccessStatusCode();
      var products = await res.Content.ReadAsAsync<IEnumerable<ProductVM>>();
      return products;
    }
    public async Task<IEnumerable<CategoriesVM>> GetCategories()
    {
      var res = await _client.GetAsync(Endpoints.Categories);
      res.EnsureSuccessStatusCode();
      var Categories = await res.Content.ReadAsAsync<IEnumerable<CategoriesVM>>();
      return Categories;
    }
  }
}