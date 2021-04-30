using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Controllers;
using LibraryShare.Categories;

namespace backend.Reponsitories.CategoryRepositories
{
  public interface ICategory
  {
    Task<CategoriesVM> GetCategory(int Id);
    Task<IEnumerable<CategoriesVM>> GetCategories();
    Task<CategoriesVM> CreateCategory(CategoryRequest categoryReq);
    Task<CategoriesVM> Updatecategory(int categoryId, CategoryRequest categoryReq);


    }
}