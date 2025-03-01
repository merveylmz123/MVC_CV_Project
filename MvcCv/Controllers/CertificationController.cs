using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificationController : Controller
    {
        // GET: Certification

        GenericRepository<Tbl_Certifications> repo = new GenericRepository<Tbl_Certifications>();
        public ActionResult Index()
        {
            var certification = repo.List();
            return View(certification);
        }

        [HttpGet]
        public ActionResult EditCertification(int id)
        {
            var certificate = repo.Find(x => x.Id == id);
            ViewBag.d = id;
            return View(certificate);
        }

        [HttpPost]
        public ActionResult EditCertification(Tbl_Certifications t)
        {
            var certificate = repo.Find(x => x.Id == t.Id);
            certificate.Description = t.Description;
            certificate.Date = t.Date;
            repo.TUpdate(certificate);
            TempData["Message"] = "Güncelleme işlemi başarılı.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCertification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertification(Tbl_Certifications p)
        {
            repo.TAdd(p);
            TempData["Message"] = "Kaydetme işlemi başarılı.";
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertification(int id)
        {
            var certification = repo.Find(x => x.Id == id);
            repo.TDelete(certification);
            TempData["Message"] = "Silme işlemi başarılı.";
            return RedirectToAction("Index");
        }
    }
}