using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin

        GenericRepository<Tbl_Admin> repo = new GenericRepository<Tbl_Admin>();

        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Tbl_Admin p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAdmin");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            Tbl_Admin t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            Tbl_Admin t = repo.Find(x => x.Id == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditAdmin(Tbl_Admin p)
        {
            if (!ModelState.IsValid)
            {
                return View("EditAdmin");
            }
            Tbl_Admin t = repo.Find(x => x.Id == p.Id);
            t.UserName = p.UserName;
            t.Password = p.Password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}