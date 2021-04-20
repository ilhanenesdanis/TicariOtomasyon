using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.personels.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult personelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepatmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult personelEkle(Personel p)
        {
            //dosya ekleme işlemi için 
            if (Request.Files.Count > 0)
            {
                string dosyaAdı = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdı + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaAdı + uzantı;
            }
            c.personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepatmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var ens = c.personels.Find(id);
            return View("PersonelGetir",ens);
        }
        public ActionResult PersonelGüncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdı = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdı + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaAdı + uzantı;
            }
            var prsn = c.personels.Find(p.PersonelId);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.DepatmanId = p.DepatmanId;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelList()
        {
            var deger = c.personels.ToList();
            return View(deger);
        }
    }
}