using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Controllers;
using backend.Models;
using backend.Services;
using LibraryShare.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend.Reponsitories.ProductReponsitories
{
    public class ProductRepository : IProduct
    {
        private readonly IBlobService _blobService;
        private readonly IMapper _mapper;
        private MyDbContext _context;
        public ProductRepository(MyDbContext context,
            IBlobService blobService,
            IMapper mapper)
        {
            _blobService = blobService;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProductVM> GetProduct(int Id)
        {
            var product = await _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id.Equals(Id));

            var productVM = _mapper.Map<ProductVM>(product);

            return productVM;
        }

        public async Task<IEnumerable<ProductVM>> GetProducts()
        {
            var products = await _context.Products
              .Include(product => product.Images)
              .Include(p => p.Category)
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

            product.IsDelete = false;
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductVM>(product);

            return productRes;
        }

        public async Task<ProductVM> CreateProduct(ProductRequest productReq)
        {
            var product = new Product
            {
                Name = productReq.Name,
                Price = productReq.Price,
                CategoryId = productReq.CategoryId
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            foreach (var image in productReq.Images)
            {
                var imageUrl = await UploadImage(image);

                var newImage = new Image
                {
                    ProductId = product.Id,
                    pathImage = imageUrl,
                };

                await _context.Image.AddAsync(newImage);
                await _context.SaveChangesAsync();
            }

            var productRes = _mapper.Map<ProductVM>(product);

            return productRes;
        }

        public async Task<ProductVM> UpdateProduct(int productId, ProductRequest productReq)
        {
            var existProduct = await _context.Products.FindAsync(productId);

            // if (existProduct == null)
            // {
            //   throw new NotFoundException($"Product id {productId} not found");
            // }
            existProduct.Name = productReq.Name;
            existProduct.Price = productReq.Price;
            existProduct.CategoryId = productReq.CategoryId;
            // existProduct.IsDelete = productReq.isDelete;


            if (productReq.Images is not null)
            {
                foreach (var image in productReq.Images)
                {
                    var imageUrl = await UploadImage(image);

                    var newImage = new Image
                    {
                        ProductId = existProduct.Id,
                        pathImage = imageUrl,
                    };

                    await _context.Image.AddAsync(newImage);
                }

            }
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductVM>(existProduct);

            return productRes;
        }

        private async Task<string> UploadImage(IFormFile imageFile)
        {
            var image = await _blobService.UploadFileBlobAsync(imageFile.OpenReadStream(), imageFile.ContentType);
            return image.AbsoluteUri;
        }
    }
}