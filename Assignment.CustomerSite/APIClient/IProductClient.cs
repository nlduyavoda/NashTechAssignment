using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;


namespace Assignment.CustomerSite.APIClient
{
    interface IProductClient
    {
        Task<IList<Products>> GetProducts();
    }
}
