using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Controllers;
using backend.Models;
using backend.Services;
using LibraryShare.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace backend.Reponsitories.CategoryRepositories
{
    public class CategoryRepository : ICategory
    {
        private readonly IBlobService _blobService;
        private IMapper _mapper;
        private MyDbContext _context;
        private readonly IStorageService _storageService;
        public CategoryRepository(MyDbContext context,
           IMapper mapper,IStorageService storageService)
        {
            _mapper = mapper;
            _context = context;
            _storageService = storageService;
        }
        


        public async Task<CategoriesVM> GetCategory(int Id)
        {
            var Categories = await _context.Categories
              .Include(p => p.Products)
              .ThenInclude(i => i.Images)
              .FirstOrDefaultAsync(p => p.Id.Equals(Id));

            var CategoriesVM = _mapper.Map<CategoriesVM>(Categories);
            return CategoriesVM;
        }
        public async Task<IEnumerable<CategoriesVM>> GetCategories()
        {
            var Categories = await _context.Categories
             .Include(Categories => Categories.Products)
             .ToListAsync();

            var CategoriesVM = _mapper.Map<IEnumerable<CategoriesVM>>(Categories);
            return CategoriesVM;
        }

        public async Task<CategoriesVM> Updatecategory(int Id, CategoryRequest categoryReq)
        {
            var existCategory = await _context.Categories.FindAsync(Id);
            existCategory.Name = categoryReq.Name;
            
            if (categoryReq.pathImage is not null)
            {
                var imageUrl = await UploadImage(categoryReq.pathImage);
                existCategory.pathImage = await UploadImage(categoryReq.pathImage);
                // var newImage = new Image
                // {
                //     ProductId = existCategory.Id,
                //     pathImage = imageUrl,
                // };

                // await _context.Image.AddAsync(newImage);
            }
            await _context.SaveChangesAsync();


            var productRes = _mapper.Map<CategoriesVM>(existCategory);

            return productRes;
        }

        public async Task<CategoriesVM> CreateCategory(CategoryRequest categoryReq)
        {
            var category = new Category
            {
                Name = categoryReq.Name
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            {
                var Name = categoryReq.Name;


                var imageUrl = await UploadImage(categoryReq.pathImage);
                category.pathImage = await UploadImage(categoryReq.pathImage);
                // var newImage = new Image
                // {
                //     Id = category.Id,
                //     pathImage = imageUrl,
                // };

                // await _context.Image.AddAsync(newImage);

                await _context.SaveChangesAsync();


            }

            var categoryResponse = _mapper.Map<CategoriesVM>(category);

            return categoryResponse;
        }
        private async Task<string> UploadImage(IFormFile imageFile)
        {
            var ImageUrl = await _storageService.SaveFile(imageFile);
            // var image = await _blobService.UploadFileBlobAsync(imageFile.OpenReadStream(), imageFile.ContentType);
            return ImageUrl;
        }
    }
}