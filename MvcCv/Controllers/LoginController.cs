using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            DbCvEntities db = new DbCvEntities();
            var value = db.Tbl_Admin.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                Session["UserName"] = value.UserName.ToString();
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}