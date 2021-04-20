using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var deger = c.carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(deger);
        }
        public ActionResult Siparişlerim()
        {
            var mail = (string)Session["CariMail"];
            var deger = c.carilers.Where(y => y.CariMail == mail.ToString()).Select(z => z.CariId).FirstOrDefault();
            var degerler = c.satışHareketis.Where(t => t.CariId == deger).ToList();
            return View(degerler);
        }
    }
}