using AutoMapper;
using backend.Models;
using LibraryShare.Product;

namespace backend.Automapper
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<ProductVM, Product>()
              // .AfterMap((pm, p) => pm.CategoryName = p.Category.Name)
              .ForPath(product => product.Category.Name, i =>
                  i.MapFrom(productVM => productVM.CategoryName))
              .ForMember(product => product.Images, i =>
                  i.MapFrom(productVM => productVM.Images))
              .ReverseMap();
        }
    }
}