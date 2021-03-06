using System;
using System.Net.Http;
using System.Net.Http.Headers;
using client.services.HttpClientService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace client.Extension
{
  public static class ClientRegister
  {
    public static void AddHttpClientCusTom(this IServiceCollection service, IConfiguration config)
    {
      service.AddHttpClient();
      service.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      var configureClient = new Action<IServiceProvider, HttpClient>(async (provider, client) =>
      {
        var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
        var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");
        client.BaseAddress = new Uri(config["BackEndUrl"]);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
      });

      service.AddHttpClient<IHttpClientServices, HttpClientServices>(configureClient);
    }
  }
}