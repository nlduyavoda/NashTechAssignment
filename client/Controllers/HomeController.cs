using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using client.Models;
using Microsoft.AspNetCore.Authorization;
using client.services.HttpClientService;
using LibraryShare.Product;



namespace client.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientServices _client;
    public HomeController(ILogger<HomeController> logger, IHttpClientServices client)
    {
      _logger = logger;
      _client = client;
    }
    public async Task<ActionResult<IEnumerable<ProductVM>>> Index()
    {
      var product = await _client.GetProducts();
      return View(product);
    }
    [Authorize]
    public IActionResult Privacy()
    {
      return View("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
