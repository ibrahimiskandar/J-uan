using J_uan.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J_uan.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public AppDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Slider> Slides { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<ProductColors> ProductColors { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ProductsCategories> ProductsCategories { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Brands> Brands
        {
            get; set;
        }
    }
}
