using Drippyz.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drippyz.Controllers
{
    public class ProductController : Controller
    {
        //declare app db context 
        private readonly AppDbContext _context;
        //constructor
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        //default action result 
        //var data = return products in this controller and also  pass the data as a parameter to the view
        //Asynchronous method
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
    }
}
