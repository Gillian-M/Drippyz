using Drippyz.Data.Base;
using Drippyz.Models;

namespace Drippyz.Data.Services
{
    public class StoresService : EntityBaseRepository<Store>, IStoresService
    {
        //pass appdb context file as a parameter
        public StoresService(AppDbContext context) : base(context)
        {
        }
    }
}
