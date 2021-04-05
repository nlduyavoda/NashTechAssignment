using Microsoft.EntityFrameworkCore;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
         : base(options)
        {
        }

    public DbSet<Products> Products { get; set;}
    public DbSet<User> Users{ get; set; }
    public DbSet<Category> categories { get; set; }
    }
}
