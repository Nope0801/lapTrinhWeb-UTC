using Day13Lab_231230949_14_11_2025_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day13Lab_231230949_14_11_2025_2.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        AspnetLab4Context db;
        List<Major> majors;
        public MajorViewComponent(AspnetLab4Context _context)
        {
            db = _context;
            majors = db.Majors.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderMajor", majors);
        }
    }
}
