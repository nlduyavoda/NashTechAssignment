using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using backend.Models;
using backend.Reponsitories.CategoryRepositories;
using backend.Reponsitories.ProductReponsitories;
using backend.Reponsitories.RatingRepositories;
using backend.Services;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Application"));
            });

            services.AddScoped(x =>
            {
                return new BlobServiceClient(Configuration.GetConnectionString("BlobAccessKey"));
            });

            services.AddScoped<IBlobService, BlobService>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IStorageService, FileStorageService>();


            services.AddDefaultIdentity<IdentityUser>(options =>
                options.SignIn.RequireConfirmedAccount = false)
                      .AddRoles<IdentityRole>()
                      .AddEntityFrameworkStores<MyDbContext>();

            services.ConfigureApplicationCookie(config =>
              {
                  config.LoginPath = "/Auth/Login";
                  config.LogoutPath = "/Auth/Logout";
              });

            var clientUrls = new Dictionary<string, string>
            {
                ["Mvc"] = Configuration["Services:Mvc"],
                ["Admin"] = Configuration["Services:Admin"],
            };

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                // options.Authentication

                options.EmitStaticAudienceClaim = true;
            })
                .AddAspNetIdentity<IdentityUser>()
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryApiResources(Config.Apis)
                .AddInMemoryClients(Config.Clients(clientUrls["Mvc"], clientUrls["Admin"]))
                // .AddTestUsers(TestUsers.Users)
                .AddProfileService<ProfileService>()
                .AddDeveloperSigningCredential();

            services.AddAuthentication()
            .AddLocalApi("Bearer", option =>
            {
                option.ExpectedScope = "api1";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireAuthenticatedUser();
                });
            });


            services.AddControllersWithViews();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors(o =>
            {
                o.AllowAnyHeader();
                o.AllowAnyMethod();
                o.AllowAnyOrigin();
            });
            app.UseRouting();
            app.UseIdentityServer();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
