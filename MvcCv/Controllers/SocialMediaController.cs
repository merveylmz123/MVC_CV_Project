using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia

        GenericRepository<Tbl_SocialMedia> repo = new GenericRepository<Tbl_SocialMedia>();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(Tbl_SocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSocialMedia(int id)
        {
            var values = repo.Find(x => x.Id == id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditSocialMedia(Tbl_SocialMedia p)
        {
            var values = repo.Find(x => x.Id == p.Id);
            values.Name = p.Name;
            values.Status = true;
            values.Link = p.Link;
            values.Icon = p.Icon;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var values = repo.Find(x => x.Id == id);
            values.Status = false;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}