using AutoMapper;
using backend.Models;
using LibraryShare.Categories;

namespace backend.Automapper
{
  public class CategoryMap : Profile
  {
    public CategoryMap()
    {
      CreateMap<CategoriesVM, Category>()
       .ForMember(Category => Category.Products, i =>
            i.MapFrom(CategoriesVM => CategoriesVM.Products))
            .ReverseMap();
    }
  }
}
