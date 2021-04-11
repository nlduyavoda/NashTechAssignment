using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using backend.Models;
using LibraryShare.Rating;
using Microsoft.AspNetCore.Http;

namespace backend.Reponsitories.RatingRepositories
{
  public class RatingRepository : IRatingRepository
  {
    private readonly IMapper _mapper;
    private readonly MyDbContext _context;
    private readonly IHttpContextAccessor _IhttpContextAccessor;
    public RatingRepository(MyDbContext context,
    IMapper mapper, IHttpContextAccessor IHttpContextAccessor)
    {
      _mapper = mapper;
      _context = context;
      _IhttpContextAccessor = IHttpContextAccessor;

    }

    public async Task<bool> Create(RatingRes ratingRes)
    {
      var rate = _mapper.Map<Rating>(ratingRes);

      var userId = _IhttpContextAccessor.HttpContext.User
      .FindFirstValue("sub");

      rate.UserId = userId;

      await _context.AddAsync(rate);
      await _context.SaveChangesAsync();

      var product = await _context.Products.FindAsync(ratingRes.ProductId);

      var rates = await Task.FromResult((int)_context.Ratings
        .Where(rate => rate.ProductId.Equals(ratingRes.ProductId))
        .Select(rate => rate.Value)
        .Average());

      product.Rated = rates;
      await _context.SaveChangesAsync();

      return true;
    }
  }
}