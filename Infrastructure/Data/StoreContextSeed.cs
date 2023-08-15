using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        // Just having Task here means we're not returning anything, just updating our database
        public static async Task SeedAsync(StoreContext context)
        {
            // Read JSON then Deserialze into our C# objects then add them to our Database
            if (!context.ProductBrands.Any()) // checks if there are any entries in our ProductBrands table
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json"); // this will be called from API
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }

            // Order is important, we need our ProductTypes and ProductBrands to be seeded before our Products
            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            // If we have any pending changes, save them to our DB
            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}