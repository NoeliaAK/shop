using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.ProductType> ProductTypes { get; set; }
        public DbSet<Models.SalePoint> SalePoints { get; set; }
        public DbSet<Models.SalePointProduct> SalePointProducts { get; set; }
    }
}
