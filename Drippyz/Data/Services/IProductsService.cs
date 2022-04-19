using Drippyz.Data.Base;
using Drippyz.Models;

namespace Drippyz.Data.Services
{
    public interface IProductsService:IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
    }
}
