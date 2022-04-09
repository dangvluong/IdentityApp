using IdentityApp.Models;

namespace IdentityApp
{
    public static class DataSeeder
    {
        public static void SeedProduct(ProductDbContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Kayak",
                        Category = "Watersports",
                        Price = 275
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Lifejacket",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Soccer Ball",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Corner Flags",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Stadium",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Thinking Cap",
                        Category = "Chess",
                        Price = 16
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "Unsteady Chair",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "Human Chess Board",
                        Category = "Chess",
                        Price = 75
                    }, new Product
                    {
                        Id = 9,
                        Name = "Bling-Bling King",
                        Category = "Chess",
                        Price = 1200
                    }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
        public static WebApplication SeedDataToDb(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetService<ProductDbContext>();
                SeedProduct(context);
            }
            return app;
        }
    }
}
