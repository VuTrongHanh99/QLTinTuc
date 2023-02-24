using Core.Application.Interfaces;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace WebTinTuc.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuMainServices _services;

        public HomeController(IMenuMainServices services,ILogger<HomeController> logger)
        {
            _logger = logger;
            _services = services;
        }
        // GET: MenuMainController
        public async Task<ActionResult> Index()
        {
            var results = new List<MenuMainEntity>();
            results = await _services.GetAllService();
            ViewData["MenuMain"] = results;
            ////option 3: using Model
            //return View(results);

            return View();
        }

        
        public  async Task<List<MenuMainEntity>> GetMenuMains()
        {
            var results = new List<MenuMainEntity>();
            results =await  _services.GetAllService();
            
            return results;
        }
    }
}