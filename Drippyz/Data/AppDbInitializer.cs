using Drippyz.Models;

namespace Drippyz.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Reference to AppDbContext file sending/getting data from database
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //Ensures db creation
                context.Database.EnsureCreated();


                //Store seeding the database (Add all data) store and products
                if (!context.Stores.Any())
                {
                    //If there is no store in the database need to add a store
                    context.Stores.AddRange(new List<Store>()
                    {
                       //pass parameter store into a list
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
                //If there is no products in the database need to add products

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
                        },

                        new Product()
                        {
                            
                            Name = "Chocolte",
                            Description = "500ML Home made Chocolate ice cream.",
                            Price = 12.00,
                            ImageURL = "https://sample/images/products/product-2",
                            ProductCategory = ProductCategory.Bar,
                            StoreId = 1
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























