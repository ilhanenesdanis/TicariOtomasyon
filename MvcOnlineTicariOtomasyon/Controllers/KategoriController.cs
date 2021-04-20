using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        //sayfalama yapmak için bi paket yüklemesi yapılmaıs lazım
        //paging mvc adlı paket kurulacak
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.kategoris.ToList().ToPagedList(sayfa, 5);

            return View(degerler);
        }
        [HttpGet]
        public ActionResult kategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kategoriEkle(Kategori k)
        {
            c.kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int Id)
        {
            var kate = c.kategoris.Find(Id);
            c.kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int Id)
        {
            var kate = c.kategoris.Find(Id);
            return View("KategoriGetir", kate);

        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktg = c.kategoris.Find(k.KategoriId);
            ktg.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}