using Drippyz.Data;
using Drippyz.Data.Services;
using Drippyz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drippyz.Controllers
{
    public class StoreController : Controller
    {
        // //inject IStore service 
        private readonly IStoresService _service;
        //constructor
        public StoreController(IStoresService service)
        {
            _service = service;
        }

        //default action result 
        //var data = return store in this controller and also  pass the data as a parameter to the view
        public async Task<IActionResult> Index()
        {
            var allStores = await _service.GetAllAsync();
            return View(allStores);
        }

        //Get Request Create View 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Glyph,Name,Description")]Store store)
        {
            if (!ModelState.IsValid) return View(store);
            await _service.AddAsync(store);
            return RedirectToAction(nameof(Index));
        }
    }
}
