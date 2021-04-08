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
    public async Task<IEnumerable<CategoriesVM>> GetCategories()
    {
      var Categories = await _context.Categories
        .ToListAsync();

      var CategoriesRes = _mapper.Map<IEnumerable<CategoriesVM>>(Categories);
      return CategoriesRes;
    }

    // public Task<CategoriesVM> GetCategory(int Id)
    // {
    //   throw new System.NotImplementedException();
    // }
  }
}