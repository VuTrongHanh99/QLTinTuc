using Microsoft.AspNetCore.Mvc;

namespace WebTinTuc.FrontEnd.Controllers
{
    public class TinTucController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
