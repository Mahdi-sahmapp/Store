using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.SeedData
{
    public class GenerateData
    {
        public static async Task SeedDataAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {

                if (!await context.ProductBrands.AnyAsync())
                {

                    var Brands = brands();
                    await context.ProductBrands.AddRangeAsync(Brands);
                    await context.SaveChangesAsync();
                }

                if (!await context.ProductTypes.AnyAsync())
                {

                    var types = Types();
                    await context.ProductTypes.AddRangeAsync(types);
                    await context.SaveChangesAsync();
                }

                if (!await context.Products.AnyAsync())
                {

                    var prosucts = Products();
                    await context.Products.AddRangeAsync(prosucts);
                    await context.SaveChangesAsync();
                }


            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<GenerateData>();

                logger.LogError(e, "Seed Data Error");
            }
        }

        private static List<Product> Products()
        {
            List<Product> products = new List<Product>();
            products = new List<Product>()
                    {
                        new ()
                        {
                            Description = "About product1 description......",
                            PictureUrl= "",
                            Price=15000,
                            Title = "Product1",
                            Summary="test summary",
                            ProductBrandId=1,
                            ProductTypeId=1,
                        },
                        new ()
                        {
                            Description = "About product2 description......",
                            PictureUrl= "",
                            Price=15000,
                            Title = "Product2",
                            Summary="test summary",
                            ProductBrandId=1,
                            ProductTypeId=1,
                        },
                        new ()
                        {
                            Description = "About product3 description......",
                            PictureUrl= "",
                            Price=15000,
                            Title = "Product3",
                            Summary="test summary",
                            ProductBrandId=1,
                            ProductTypeId=1,
                        },
                        new ()
                        {
                            Description = "About product4 description......",
                            PictureUrl= "",
                            Price=15000,
                            Title = "Product4",
                            Summary="test summary",
                            ProductBrandId=1,
                            ProductTypeId=1,
                        },

                    };

            return products;
        }
        private static List<ProductBrand> brands()
        {
            List<ProductBrand> brands = new List<ProductBrand>();
            brands = new List<ProductBrand>()
                    {
                        new()
                        {
                            Description="Prodcu Brand1 description......",
                            Summary = "shadhjasdjkhj sjjsa iuio  sklkj op kjlasi ",
                            Title = "Brand1",
                        },
                        new()
                        {
                            Description="Prodcu Brand2 description......",
                            Summary = "shadhjasdjkhj sjjsa iuio  sklkj op kjlasi ",
                            Title = "Brand2",
                        },
                    };

            return brands;
        }
        private static List<ProductType> Types()
        {
            List<ProductType> types = new List<ProductType>();
            types = new List<ProductType>()
                    {
                        new()
                        {
                            Description="Prodcu Typ1 description......",
                            Summary = "shadhjasdjkhj sjjsa iuio  sklkj op kjlasi ",
                            Title = "Typ1",
                        },
                        new()
                        {
                            Description="Prodcu Typ2 description......",
                            Summary = "shadhjasdjkhj sjjsa iuio  sklkj op kjlasi ",
                            Title = "Typ2",
                        },
                    };

            return types;
        }
    }
}
