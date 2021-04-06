using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Models;
using LibraryShare.Product;

namespace backend.Reponsitories.ProductReponsitories
{
  public class ProductRepository : IProduct
  {
    private readonly IMapper _mapper;
    private MyDbContext _context;
    public ProductRepository(MyDbContext context,
        IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }
    public async Task<ProductVM> GetProduct(double Id)
    {
      var product = await _context.Products.FindAsync(Id);
      var productVM = _mapper.Map<ProductVM>(product);

      return productVM;
    }

    public IEnumerable<ProductVM> GetProducts()
    {
      return new List<ProductVM>
      {
          new ProductVM {
              Name = "test1",
              Price = 1000
          },
      };
    }
  }
}