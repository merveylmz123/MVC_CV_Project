using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        GenericRepository<Tbl_About> repo = new GenericRepository<Tbl_About>();

        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(Tbl_About p)
        {
            var values = repo.Find(x => x.Id == 1);
            values.Name = p.Name;
            values.Surname = p.Surname;
            values.Address = p.Address;
            values.Phone = p.Phone;
            values.Mail = p.Mail;
            values.Description = p.Description;
            values.Photo = p.Photo;
            repo.TUpdate(values);
            TempData["Message"] = "Güncelleme işlemi başarılı.";
            return RedirectToAction("Index");
        }
    }
}