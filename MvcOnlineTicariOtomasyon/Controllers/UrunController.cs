using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urun = from x in c.ürünlers select x;
            if (!string.IsNullOrEmpty(p))
            {
                urun = urun.Where(y => y.UrunAd.Contains(p));
            }
           
            return View(urun.ToList());
        }
        [HttpGet]
        public ActionResult yeniurun()
        {
            List<SelectListItem> deger1 = (from x in c.kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult yeniurun(Ürünler p)
        {
            c.ürünlers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.ürünlers.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var deger = c.ürünlers.Find(id);
            return View("UrunGetir", deger);
        }
        public ActionResult UrunGüncelle(Ürünler p)
        {
            var urn = c.ürünlers.Find(p.UrunId);
            urn.AlışFiyat = p.AlışFiyat;
            urn.Durum = p.Durum;
            urn.kategoriid = p.kategoriid;
            urn.Marka = p.Marka;
            urn.SatışFiyat = p.SatışFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListe()
        {
            var deger = c.ürünlers.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult SatısYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = c.ürünlers.Find(id);
            
            ViewBag.dgr1 = deger1.UrunId;
            ViewBag.dgr2 = deger1.SatışFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatısYap(SatışHareketi p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.satışHareketis.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Satış");
        }


    }
}