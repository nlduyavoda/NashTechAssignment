using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryShare.Categories;
using LibraryShare.Product;

namespace client.services.HttpClientService
{
  public interface IHttpClientServices
  {
    Task<ProductVM> GetProductById(int id);
    Task<IEnumerable<ProductVM>> GetProducts();
    Task<CategoriesVM> GetCategoriesById(int id);
    Task<IEnumerable<CategoriesVM>> GetCategories();

  }
}