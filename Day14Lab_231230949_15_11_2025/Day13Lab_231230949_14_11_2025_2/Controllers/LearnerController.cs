using Day13Lab_231230949_14_11_2025_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day13Lab_231230949_14_11_2025_2.Controllers
{
    public class LearnerController : Controller
    {
        private AspnetLab4Context db;
        public LearnerController(AspnetLab4Context context)
        {
            db = context;
        }
        public IActionResult Index(int? mid)
        {
            var learners = db.Learners.Include(m => m.Major).ToList();
            return View(learners);
        }
        public IActionResult LearnerByMajorID(int mid)
        {
            var learners = db.Learners
                .Where(l => l.MajorId == mid)
                .Include(m => m.Major).ToList();
            return PartialView("LearnerTable", learners);
        }
        public IActionResult Create()
        {
            var majors = new List<SelectListItem>();
            foreach (var item in db.Majors)
            {
                majors.Add(new SelectListItem
                {
                    Text = item.MajorName,
                    Value = item.MajorId.ToString()
                });
            }
            ViewBag.MajorID = majors;
            ViewBag.MajorID = new SelectList(db.Majors, "MajorId", "MajorName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName, LastName, MajorId, EnrolmentDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorId", "MajorName");
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }
            var learner = db.Learners.Find(id);
            if(learner == null)
            {
                return NotFound();
            }
            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", learner.MajorId);
            return View(learner);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,
            [Bind("LearnerId, FirstMidName, LastName, MajorId, EnrolmentDate")] Learner learner)
        {
            if(id != learner.LearnerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorId = new SelectList(db.Majors, "MajorId", "MajorName", learner.MajorId);
            return View(learner);
        }
        private bool LearnerExists(int learnerId)
        {
            return (db.Learners?.Any(e => e.LearnerId == learnerId)).GetValueOrDefault();
        }

        public IActionResult Delete(int id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }
            var learner = db.Learners.Include(l => l.Major).Include(e => e.Enrollments).FirstOrDefault(m => m.LearnerId == id);
            if(learner == null)
            {
                return NotFound();
            }
            if(learner.Enrollments.Count() > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }
            return View(learner);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if(db.Learners == null)
            {
                return Problem("Entity set 'Leaners' is null.");
            }
            var learner = db.Learners.Find(id);
            if(learner != null)
            {
                db.Learners.Remove(learner);
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
