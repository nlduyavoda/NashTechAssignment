using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using client.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace client
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      // JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

      services.AddAuthentication(options =>
          {
            options.DefaultScheme = "Cookies";
            options.DefaultChallengeScheme = "oidc";
          })
          .AddCookie("Cookies", options =>
          {
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.None;
          })
          .AddOpenIdConnect("oidc", options =>
          {
            options.Authority = "http://localhost:5000";
            options.RequireHttpsMetadata = false;
            options.GetClaimsFromUserInfoEndpoint = true;
            // options.

            options.ClientId = "client";
            options.ClientSecret = "Secret";
            options.ResponseType = "code";
            options.SignInScheme = "Cookies";
            options.RequireHttpsMetadata = false;
            options.SaveTokens = true;
            // options.TokenValidationParameters = new TokenValidationParameters
            // {
            //   NameClaimType = "name",
            //   RoleClaimType = "role"
            // };
          });

      services.AddHttpClientCusTom(Configuration);

      services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseCors(option =>
      {
        option.AllowAnyOrigin();
      });
      // app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
