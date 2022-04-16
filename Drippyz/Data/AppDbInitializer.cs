using Drippyz.Models;

namespace Drippyz.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                //Store seeding the database 
                if (!context.Stores.Any())
                {
                    context.Stores.AddRange(new List<Store>()
                    {
                        new Store()
                        {

                            Glyph = "https://sample/images/store/store-1",
                            Name = "Drippyz",
                            Description = "Ice cream company",

                        }

                    });
                    context.SaveChanges();
                }
                //Products

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Vanilla",
                            Description = "500ML Home made ice cream.",
                            Price = 11.00,
                            ImageURL = "https://sample/images/products/product-1",
                            ProductCategory = ProductCategory.Bar
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        internal static void Seed()
        {
            throw new NotImplementedException();
        }
    }
}























