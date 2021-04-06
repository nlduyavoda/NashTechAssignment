using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using client.Models;
using Microsoft.AspNetCore.Authorization;
using backend.Reponsitories.ProductReponsitories;

namespace client.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IProduct _product;

    public HomeController(ILogger<HomeController> logger,
      IProduct product)
    {
      _logger = logger;
      _product = product;
    }

    public IActionResult Index()
    {
      return View();
    }
    public async Task<IActionResult> Product()
    {
      var product = await _product.GetProductById(1);
      return View(product);
    }


    [Authorize]
    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
