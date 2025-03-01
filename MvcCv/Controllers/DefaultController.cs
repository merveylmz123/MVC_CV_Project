using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_About.ToList();
            return View(values);
        }
        public PartialViewResult SocialMedia()
        {
            var socialMedia = db.Tbl_SocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(socialMedia);
        }

        public PartialViewResult Experience()
        {
            var experience = db.Tbl_Experience.ToList();
            return PartialView(experience);
        }

        public PartialViewResult Education()
        {
            var education = db.Tbl_Education.ToList();
            return PartialView(education);
        }

        public PartialViewResult Skills()
        {
            var skills = db.Tbl_Skills.ToList();
            return PartialView(skills);
        }

        public PartialViewResult Interests()
        {
            var interests = db.Tbl_Interests.ToList();
            return PartialView(interests);
        }

        public PartialViewResult Certifications()
        {
            var certifications = db.Tbl_Certifications.ToList();
            return PartialView(certifications);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Tbl_Contact t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_Contact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}