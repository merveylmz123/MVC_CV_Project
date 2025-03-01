using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education

        GenericRepository<Tbl_Education> repo = new GenericRepository<Tbl_Education>() { };

        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Tbl_Education p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            TempData["Message"] = "Kaydetme işlemi başarılı.";
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var education = repo.Find(x => x.Id == id);
            repo.TDelete(education);
            TempData["Message"] = "Silme işlemi başarılı.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var education = repo.Find(x => x.Id == id);
            return View(education);
        }

        [HttpPost]
        public ActionResult EditEducation(Tbl_Education t)
        {
            if (!ModelState.IsValid)
            {
                return View("EditEducation");
            }
            var education = repo.Find(x => x.Id == t.Id);
            education.Title = t.Title;
            education.Subtitle1 = t.Subtitle1;
            education.Subtitle2 = t.Subtitle2;
            education.Date = t.Date;
            education.GPA = t.GPA;
            repo.TUpdate(education);
            TempData["Message"] = "Güncelleme işlemi başarılı.";
            return RedirectToAction("Index");
        }
    }
}