using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryShare.Product;

namespace backend.Reponsitories.ProductReponsitories
{
  public interface IProduct
  {
    Task<ProductVM> GetProduct(int Id);
    Task<IEnumerable<ProductVM>> GetProducts();
  }
}