using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using client.services.HttpClientService;
using LibraryShare.Product;
using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
  public class ProductController : Controller
  {
    private readonly IHttpClientServices _client;
    public ProductController(IHttpClientServices client)
    {
      _client = client;
    }
    public async Task<ActionResult<IEnumerable<ProductVM>>> Index()
    {
      var product = await _client.GetProducts();
      return View(product);
    }


  }
}