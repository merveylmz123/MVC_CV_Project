using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class InterestsController : Controller
    {
        // GET: Interests

        GenericRepository<Tbl_Interests> repo = new GenericRepository<Tbl_Interests>();

        [HttpGet]
        public ActionResult Index()
        {
            var interests = repo.List();
            return View(interests);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Interests p)
        {
            var values = repo.Find(x => x.Id == 1);
            values.Description1 = p.Description1;
            values.Description2 = p.Description2;
            repo.TUpdate(values);
            TempData["Message"] = "Güncelleme işlemi başarılı.";
            return RedirectToAction("Index");
        }
    }
}