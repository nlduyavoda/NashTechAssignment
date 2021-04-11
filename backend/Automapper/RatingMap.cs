using AutoMapper;
using backend.Models;
using LibraryShare.Rating;

namespace backend.Automapper
{
  public class RatingMap : Profile
  {
    public RatingMap()
    {
      CreateMap<RatingRes, Rating>().ReverseMap();
    }
  }
}