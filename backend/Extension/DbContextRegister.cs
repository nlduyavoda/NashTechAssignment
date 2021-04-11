using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace backend.Extension
{
  public static class DbContextRegister
  {
    public static void AddContext(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<MyDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection")));
    }
  }
}