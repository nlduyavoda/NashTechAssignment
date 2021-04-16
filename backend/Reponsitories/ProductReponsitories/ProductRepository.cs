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

        public async Task<ProductVM> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            // if (product == null)
            // {
            //   throw new NotFoundException($"{productId} Not Found");
            // }

            product.IsDelete = true;
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductVM>(product);

            return productRes;
        }

        public async Task<ProductVM> CreateProduct(ProductVM productReq)
        {
            var product = _mapper.Map<Product>(productReq);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductVM>(product);

            return productRes;
        }

        public async Task<ProductVM> UpdateProduct(int productId, ProductVM productReq)
        {
            var existProduct = await _context.Products.FindAsync(productId);

            // if (existProduct == null)
            // {
            //   throw new NotFoundException($"Product id {productId} not found");
            // }

            _context.Entry<Product>(existProduct).CurrentValues.SetValues(productReq);

            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductVM>(existProduct);

            return productRes;
        }
    }
}