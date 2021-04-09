using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Models;
using LibraryShare.Product;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ProductVM> GetProduct(int Id)
    {
      var product = await _context.Products
          .Include(p => p.Images)
          .FirstOrDefaultAsync(p => p.Id.Equals(Id));

      var productVM = _mapper.Map<ProductVM>(product);

      return productVM;
    }

    public async Task<IEnumerable<ProductVM>> GetProducts()
    {
      var products = await _context.Products
        .Include(product => product.Images)
        .ToListAsync();

      var ProductsRes = _mapper.Map<IEnumerable<ProductVM>>(products);
      return ProductsRes;
    }
  }
}