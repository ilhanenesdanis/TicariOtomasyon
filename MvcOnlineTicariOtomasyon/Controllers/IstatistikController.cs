using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.ürünlers.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.ürünlers.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.ürünlers select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.ürünlers.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.ürünlers orderby x.SatışFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.ürünlers orderby x.SatışFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.ürünlers.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.ürünlers.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.ürünlers.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = c.ürünlers.Where(u => u.UrunId == (c.satışHareketis.GroupBy(x => x.UrunId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = c.satışHareketis.Sum(x => x.ToplamFiyat).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;

            var deger15 = c.satışHareketis.Count(x => x.Tarih == bugun).ToString();


            ViewBag.d15 = deger15;

            var deger16 = c.satışHareketis.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamFiyat).ToString();

            ViewBag.d16 = deger16;


            return View();
        }
        public ActionResult KolayTablo()
        {
            var sorgu = from x in c.carilers
                        group x by x.CariSehir into g
                        select new SınıfGroup
                        {
                            Sehir = g.Key,
                            Sayı = g.Count()

                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu = from x in c.personels
                        group x by x.Departman.DepartmanAd into g
                        select new SınıfGroup2
                        {
                            Departman = g.Key,

                            sayı = g.Count()
                        };

            return PartialView(sorgu.ToList());
        }
        public PartialViewResult partial2()
        {
            var sorgu = c.carilers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult partial3()
        {
            var sg = c.ürünlers.ToList();
            return PartialView(sg);
        }
        public PartialViewResult partial4()
        {
            var sorgu = from x in c.ürünlers
                        group x by x.Marka into g
                        select new snfgrp3
                        {
                            Marka = g.Key,

                            Sayı = g.Count()
                        };

            return PartialView(sorgu.ToList());

            
        }
    }
}