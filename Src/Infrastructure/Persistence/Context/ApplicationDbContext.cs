using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductType> ProductTypes => Set<ProductType>();
        public DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelbuilder.Entity<Product>().HasQueryFilter(a => a.IsDelete == false);
            modelbuilder.Entity<ProductBrand>().HasQueryFilter(a => a.IsDelete == false);
            modelbuilder.Entity<ProductType>().HasQueryFilter(a => a.IsDelete == false);
        }
    }
}
