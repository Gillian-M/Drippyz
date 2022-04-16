using Drippyz.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drippyz.Controllers
{
    public class StoreController : Controller
    {
        //declare app db context 
        private readonly AppDbContext _context;
        //constructor
        public StoreController(AppDbContext context)
        {
            _context = context;
        }

        //default action result 
        //var data = return store in this controller and also  pass the data as a parameter to the view
        public async Task<IActionResult> IndexAsync()
        {
            
            return View(await _context.Stores.ToListAsync());
            
        }
    }
}
