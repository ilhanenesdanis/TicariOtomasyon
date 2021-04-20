using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatışController : Controller
    {
        // GET: Satış
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.satışHareketis.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniSatıs()
        {
            List<SelectListItem> deger1 = (from x in c.ürünlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd+" "+x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd+" "+x.PersonelSoyad ,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dg1 = deger1;
            ViewBag.dg2 = deger2;
            ViewBag.dg3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatıs(SatışHareketi s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.satışHareketis.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatısGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.ürünlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dg1 = deger1;
            ViewBag.dg2 = deger2;
            ViewBag.dg3 = deger3;
            var deger = c.satışHareketis.Find(id);
            return View("SatısGetir", deger);
        }
        public ActionResult SatışGüncelle(SatışHareketi p)
        {
            var deger = c.satışHareketis.Find(p.SatışId);
            deger.CariId = p.CariId;
            deger.PersonelId = p.PersonelId;
            deger.UrunId = p.UrunId;
            deger.Tarih = p.Tarih;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.ToplamFiyat = p.ToplamFiyat;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        //pdf çıktı almak
        public ActionResult SatısDetay(int id)
        {
            var dgr = c.satışHareketis.Where(x => x.SatışId == id).ToList();
            return View(dgr);
        }
    }
}