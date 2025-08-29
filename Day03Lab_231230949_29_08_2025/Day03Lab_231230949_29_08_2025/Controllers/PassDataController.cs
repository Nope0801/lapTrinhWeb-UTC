using Day03Lab_231230949_29_08_2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day03Lab_231230949_29_08_2025.Controllers
{
    public class PassDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewDataDemo()
        {
            ViewData["name"] = "Hồ Tùng";
            ViewData["time"] = DateTime.Now;
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Nguyen Van A", Active = true, Age = 20, Gender = "Nam" },
                new Student { Id = 2, Name = "Tran Thi B", Active = false, Age = 21, Gender = "Nữ" },
                new Student { Id = 3, Name = "Le Van C", Active = true, Age = 19, Gender = "Nam" },
                new Student { Id = 4, Name = "Pham Thi D", Active = true, Age = 22, Gender = "Nữ" },
                new Student { Id = 5, Name = "Hoang Van E", Active = false, Age = 20, Gender = "Nam" }
            };

            ViewData["students"] = students;

            return View();
        }
    }
}
