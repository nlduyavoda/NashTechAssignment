using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Models;
using LibraryShare.Categories;
using Microsoft.EntityFrameworkCore;

namespace backend.Reponsitories.CategoryRepositories
{
  public class CategoryRepository : ICategory
  {
    private IMapper _mapper;
    private MyDbContext _context;
    public CategoryRepository(MyDbContext context,
       IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
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
  }
}