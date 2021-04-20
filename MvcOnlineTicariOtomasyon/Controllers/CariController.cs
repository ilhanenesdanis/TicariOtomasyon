using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.carilers.Where(x => x.durum == true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult yeniekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniekle(Cariler ct)
        {
            ct.durum = true;
            var deg = c.carilers.Add(ct);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var sil = c.carilers.Find(id);
            c.carilers.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult carigetir(int id)
        {
            var cari = c.carilers.Find(id);
            return View("carigetir", cari);
        }
        public ActionResult CariGüncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("carigetir");
            }
            var d = c.carilers.Find(p.CariId);
            d.CariAd = p.CariAd;
            d.CariSoyad = p.CariSoyad;
            d.CariSehir = p.CariSehir;
            d.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatıs(int id)
        {
            var cr = c.carilers.Where(x => x.CariId == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            var deger = c.satışHareketis.Where(x => x.CariId == id).ToList();
            return View(deger);
        }
    }
    
}