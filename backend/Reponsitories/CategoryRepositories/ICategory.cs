using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryShare.Categories;

namespace backend.Reponsitories.CategoryRepositories
{
  public interface ICategory
  {
    Task<CategoriesVM> GetCategory(int Id);
    Task<IEnumerable<CategoriesVM>> GetCategories();
  }
}