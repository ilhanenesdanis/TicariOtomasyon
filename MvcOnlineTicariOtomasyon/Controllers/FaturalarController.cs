using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturalarController : Controller
    {
        // GET: Faturalar
        Context c = new Context();
        public ActionResult Index()
        {
            var ftr = c.faturalars.ToList();
            return View(ftr);
        }
        [HttpGet]
        public ActionResult ftrekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ftrekle(Faturalar f)
        {
            c.faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ftrgetir(int id)
        {
            var fatura = c.faturalars.Find(id);
            return View("ftrgetir" ,fatura);
        }
        public ActionResult ftrguncelle(Faturalar f)
        {
            var fat = c.faturalars.Find(f.FaturaId);
            fat.FaturaSeriNo = f.FaturaSeriNo;
            fat.FaturaSıraNo = f.FaturaSıraNo;
            fat.Tarih = f.Tarih;
            fat.VergiDairesi = f.VergiDairesi;
            fat.Saat = f.Saat;
            fat.TeslimEden = f.TeslimEden;
            fat.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var deger = c.faturaKalems.Where(x => x.FaturaId == id).ToList();
            
            return View(deger);
        }
        [HttpGet]
        public ActionResult yenikalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenikalem(FaturaKalem p)
        {
            c.faturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}