using AutoMapper;
using backend.Models;
using LibraryShare.Image;

namespace backend.Automapper
{
  public class ImageMap : Profile
  {
    public ImageMap()
    {
      CreateMap<ImageVM, Image>().ReverseMap();
    }
  }
}