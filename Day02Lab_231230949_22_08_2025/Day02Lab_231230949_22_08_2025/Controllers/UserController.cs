using Microsoft.AspNetCore.Mvc;
using Day02Lab_231230949_22_08_2025.Models;
namespace Day02Lab_231230949_22_08_2025.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetName(string userName)
        {
            TempData["UserName"] = userName;
            return RedirectToAction("Index", "Game");
        }
    }
}
