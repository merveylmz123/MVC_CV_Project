using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(Tbl_Experience p)
        {
            repo.TAdd(p);
            TempData["Message"] = "Kaydetme işlemi başarılı.";
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            Tbl_Experience t = repo.Find(x => x.Id == id);
            TempData["Message"] = "Silme işlemi başarılı.";
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditExperience(int id)
        {
            Tbl_Experience t = repo.Find(x => x.Id == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditExperience(Tbl_Experience p)
        {
            Tbl_Experience t = repo.Find(x => x.Id == p.Id);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Date = p.Date;
            t.Description = p.Description;
            repo.TUpdate(t);
            TempData["Message"] = "Güncelleme işlemi başarılı.";
            return RedirectToAction("Index");
        }
    }
}