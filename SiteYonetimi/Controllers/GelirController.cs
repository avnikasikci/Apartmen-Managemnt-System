using SiteYonetimi.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteYonetimi.Controllers
{
    public class GelirController : Controller
    {
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();

        // GET: gelir
        public ActionResult Index(string p)
        {
            var toplamGelir = (from emp in db.TBL_Gelir select emp.GelirTl).Sum();
            var gelirler = from k in db.TBL_Gelir select k;
            if (!string.IsNullOrEmpty(p))
            {
                //  gelirler = gelirler.Aggregate((a, b) => a + b);
                //kitaplar = kitaplar.Where(x => x.AD.Contains(p));
                gelirler = gelirler.Where(x => x.GelirAd.Contains(p));
            }
            //var kitaplar = db.TBL_KITAP.ToList();
            return View(gelirler.ToList());
        }
        [HttpGet]
        public ActionResult GelirEkle()
        {
            List<SelectListItem>
           deger1 = (from i in db.TBL_KATEGORI.ToList()
                     select new SelectListItem
                     { Text = i.AD, Value = i.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult GelirEkle(TBL_Gelir p)
        {
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            p.TBL_KATEGORI = ktg;
            db.TBL_Gelir.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GelirSil(int id)
        {
            var kitap = db.TBL_KITAP.Find(id);
            var gelir = db.TBL_Gelir.Find(id);
            db.TBL_Gelir.Remove(gelir);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GelirGetir(int id)
        {
            var gdr = db.TBL_Gelir.Find(id);
            List<SelectListItem>
         deger1 = (from i in db.TBL_KATEGORI.ToList()
                   select new SelectListItem
                   { Text = i.AD, Value = i.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;


            return View("gelirGetir", gdr);
        }
        public ActionResult GelirGuncelle(TBL_Gelir p)
        {
            var gelir = db.TBL_Gelir.Find(p.İD);
            gelir.GelirAd = p.GelirAd;
            gelir.Kategori = p.Kategori;
            gelir.GelirTl = p.GelirTl;
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            gelir.Kategori = ktg.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}