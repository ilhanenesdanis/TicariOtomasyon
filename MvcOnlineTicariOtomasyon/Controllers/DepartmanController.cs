using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.departmen.Where(x => x.Durum == true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.departmen.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dep = c.departmen.Find(id);
            return View("DepartmanGetir", dep);
        }
        public ActionResult DepartmanGüncelle(Departman t)
        {
            var dp = c.departmen.Find(t.DepatmanId);
            dp.DepartmanAd = t.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var deger = c.personels.Where(x => x.DepatmanId == id).ToList();
            var dep = c.departmen.Where(x => x.DepatmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dep;
            return View(deger);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var per = c.personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dp = per;
            var deger = c.satışHareketis.Where(x => x.PersonelId == id).ToList();
            return View(deger);
        }
    }
}