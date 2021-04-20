using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.sınıf;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.ürünlers.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.kategoris.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = (from x in c.carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;
            var yapıcalak = c.toDos.ToList();
            return View(yapıcalak);
        }
    }
}