using System.Threading.Tasks;
using backend.Constatnts;
using backend.Reponsitories.RatingRepositories;
using LibraryShare.Rating;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class RatingController : ControllerBase
  {
    private readonly IRatingRepository _ratingRepository;

    public RatingController(IRatingRepository ratingRepository)
    {
      _ratingRepository = ratingRepository;
    }

    [Authorize("Bearer")]
    [HttpPost]
    public async Task<IActionResult> Create(RatingRes ratingRes)
    {
      var result = await _ratingRepository.Create(ratingRes);

      return Created(Endpoints.Rate, result);
    }

  }
}