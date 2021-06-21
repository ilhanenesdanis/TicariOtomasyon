using MvcOnlineTicariOtomasyon.Models.sınıf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string k)
        {
            var kargo = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(k))
            {
                kargo = kargo.Where(y => y.TakipKodu.Contains(k));
            }
            
            return View(kargo.ToList());
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karkterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karkterler[k1] + s2 + karkterler[k2] + s3 + karkterler[k3];
            ViewBag.tkod = kod;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay k)
        {
            c.KargoDetays.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            var deger = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            
            return View(deger);
        }
    }
}