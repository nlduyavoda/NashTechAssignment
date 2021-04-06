using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryShare.Product;

namespace backend.Reponsitories.ProductReponsitories
{
  public interface IProduct
  {
    Task<ProductVM> GetProduct(double Id);
    IEnumerable<ProductVM> GetProducts();
  }
}