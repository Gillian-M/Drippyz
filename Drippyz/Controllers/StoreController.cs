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
        //Get: Stores Details 
        public async Task<IActionResult> Details(int id)
        {
            var storeDetails = await _service.GetByIdAsync(id);
            if (storeDetails == null) return View("NotFound");
            return View(storeDetails);
        }
        //Get the store details edit Id
        //Post request after the details are updated
        public async Task<IActionResult> Edit(int id)
        {
            var storeDetails = await _service.GetByIdAsync(id);
            if (storeDetails == null) return View("NotFound");
            return View(storeDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Glyph,Name,Description")] Store store)
        {
            if (!ModelState.IsValid) return View(store);
            await _service.AddAsync(store);
            return RedirectToAction(nameof(Index));
        }
        //Store Delete
        [HttpPost, ActionName("Delete")]
        //of store exists in database call the delete confirm method
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var storeDetails = await _service.GetByIdAsync(id);
            if (storeDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
