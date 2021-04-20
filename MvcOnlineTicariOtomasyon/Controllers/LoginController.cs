using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult partial1(Cariler p)
        {
            c.carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler t)
        {
            var deger = c.carilers.FirstOrDefault(y => y.CariMail == t.CariMail && y.CariSifre == t.CariSifre);
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.CariMail, false);
                Session["CariMail"] = deger.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var bilgiler = c.admins.FirstOrDefault(x => x.KullanıcıAd == a.KullanıcıAd && x.Sifre == a.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullanıcıAd, false);
                Session["KullanıcıAd"] = bilgiler.KullanıcıAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}