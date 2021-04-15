using System.Threading.Tasks;
using LibraryShare.Rating;

namespace backend.Reponsitories.RatingRepositories
{
  public interface IRatingRepository
  {
    Task<bool> Create(RatingRes RatingRequest);
  }
}