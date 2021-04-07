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
        .ForMember(product => product.Images, i =>
            i.MapFrom(productVM => productVM.Images))
        .ReverseMap();
    }
  }
}