using Drippyz.Data;
using Drippyz.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drippyz.Controllers
{
    public class ProductController : Controller
    {
        //declare app db context 
        private readonly IProductsService _service;
        //constructor
        public ProductController(IProductsService service)
        {
            _service = service;
        }

        //default action result 
        //var data = return products in this controller and also  pass the data as a parameter to the view
        //Asynchronous method with parameters
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(n => n.Store);
            return View(allProducts);
          
        }

        //Action Get request 
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetByIdAsync(id);
            return View(productDetail);
        }

        //Get Product/Create
        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our store";
            ViewBag.Description = "This is the store description.";
            return View();
        }
    }
}
