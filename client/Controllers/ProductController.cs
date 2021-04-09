using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using client.Constatnts;
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
    [HttpGet("[controller]/{id}")]
    public async Task<ActionResult<ProductVM>> Index(int id)
    {
      var product = await _client.GetProductById(id);
      return View(product);
    }
  }
}