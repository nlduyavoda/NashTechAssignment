using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryShare.Product;

namespace backend.Reponsitories.ProductReponsitories
{
  public interface IProduct
  {
    Task<ProductVM> GetProductById(int id);
  }
}