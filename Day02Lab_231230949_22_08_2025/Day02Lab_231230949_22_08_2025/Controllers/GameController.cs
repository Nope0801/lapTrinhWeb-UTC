using Microsoft.AspNetCore.Mvc;

namespace Day02Lab_231230949_22_08_2025.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserName = TempData["UserName"];
            return View();
        }
    }
}
