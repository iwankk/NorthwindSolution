using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Northwind.Domain.Enities;

namespace Northwind.Persistence
{
    public class ShopeeDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptions options;

        public ShopeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        //ditambahkan get set di db context agar dapat diakses
        public DbSet<Product> Products { get; set; }

    }
}
