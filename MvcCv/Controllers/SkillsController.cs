using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills

        GenericRepository<Tbl_Skills> repo = new GenericRepository<Tbl_Skills>() { };
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }

        [HttpGet]
        public ActionResult AddSkills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkills(Tbl_Skills p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSkills");
            }
            repo.TAdd(p);

            TempData["Message"] = "Kaydetme işlemi başarılı.";

            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkills(int id)
        {
            var skills = repo.Find(x => x.Id == id);
            repo.TDelete(skills);
            TempData["Message"] = "Silme işlemi başarılı.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkills(int id)
        {
            var skills = repo.Find(x => x.Id == id);
            return View(skills);
        }

        [HttpPost]
        public ActionResult EditSkills(Tbl_Skills t)
        {
            if (!ModelState.IsValid)
            {
                return View("EditSkills");
            }
            var skills = repo.Find(x => x.Id == t.Id);
            skills.Description = t.Description;
            skills.Level = t.Level;
            repo.TUpdate(skills);
            TempData["Message"] = "Güncelleme işlemi başarılı.";
            return RedirectToAction("Index");
        }
    }
}