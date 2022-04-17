using Drippyz.Data;
using Drippyz.Data.Services;
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
    }
}
