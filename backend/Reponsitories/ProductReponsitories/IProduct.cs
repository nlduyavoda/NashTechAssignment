using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Controllers;
using LibraryShare.Product;

namespace backend.Reponsitories.ProductReponsitories
{
    public interface IProduct
    {
        Task<ProductVM> GetProduct(int Id);
        Task<IEnumerable<ProductVM>> GetProducts();
        Task<ProductVM> CreateProduct(ProductRequest productReq);

        Task<ProductVM> UpdateProduct(int productId, ProductVM productReq);

        Task<ProductVM> DeleteProduct(int productId);
    }
}