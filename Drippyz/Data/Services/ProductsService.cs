using Drippyz.Data.Base;
using Drippyz.Models;
using Microsoft.EntityFrameworkCore;

namespace Drippyz.Data.Services
{
    public class ProductsService:EntityBaseRepository<Product>,IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context):base(context)
        {     
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var ProductDetails = await _context.Products
               .Include(s => s.Store)
               .FirstOrDefaultAsync(n => n.Id == id);

            return ProductDetails;
        }
    }
}
