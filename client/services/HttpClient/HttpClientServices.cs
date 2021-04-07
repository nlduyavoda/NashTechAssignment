using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using client.Constatnts;
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

    public Task<IEnumerable<ProductVM>> GetProducts()
    {
      throw new System.NotImplementedException();
    }
  }
}