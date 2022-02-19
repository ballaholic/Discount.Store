using Discount.Store.Core.CartAggregate;
using Discount.Store.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;

namespace Discount.Store.Web
{
    public static class SeedData
    {
        public static readonly Item Item1 = new Item
        {
            Sku = "Vase",
            Price = 1.2m
        };
        public static readonly Item Item2 = new Item
        {
            Sku = "Big mug",
            Price = 1m
        };
        public static readonly Item Item3 = new Item
        {
            Sku = "Napkins pack",
            Price = 0.45m
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (dbContext.Items.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);
            }
        }

        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Items)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            dbContext.Items.Add(Item1);
            dbContext.Items.Add(Item2);
            dbContext.Items.Add(Item3);

            dbContext.SaveChanges();
        }
    }
}
