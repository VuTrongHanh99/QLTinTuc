using Microsoft.AspNetCore.Mvc;

namespace WebTinTuc.BackEnd.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
