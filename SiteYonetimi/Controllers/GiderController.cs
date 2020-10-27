using SiteYonetimi.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteYonetimi.Controllers
{
    public class GiderController : Controller
    {
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();

        // GET: Gider
        public ActionResult Index(string p)
        {
            var giderler = from k in db.TBL_Gider select k;
            if (!string.IsNullOrEmpty(p))
            {
                //kitaplar = kitaplar.Where(x => x.AD.Contains(p));
                giderler = giderler.Where(x => x.GiderAd.Contains(p));
            }
            //var kitaplar = db.TBL_KITAP.ToList();
            return View(giderler.ToList());
        }
        [HttpGet]
        public ActionResult GiderEkle()
        {
            List<SelectListItem>
           deger1 = (from i in db.TBL_KATEGORI.ToList()
                     select new SelectListItem
                     { Text = i.AD, Value = i.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult GiderEkle(TBL_Gider p)
        {
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            p.TBL_KATEGORI = ktg;
            db.TBL_Gider.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GiderSil(int id)
        {
            var kitap = db.TBL_KITAP.Find(id);
            var gider = db.TBL_Gider.Find(id);
            db.TBL_Gider.Remove(gider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GiderGetir(int id)
        {
            var gdr = db.TBL_Gider.Find(id);
            List<SelectListItem>
         deger1 = (from i in db.TBL_KATEGORI.ToList()
                   select new SelectListItem
                   { Text = i.AD, Value = i.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;

     
            return View("GiderGetir", gdr);
        }
        public ActionResult GiderGuncelle(TBL_Gider p)
        {
            var gider = db.TBL_Gider.Find(p.İD);
            gider.GiderAd = p.GiderAd;
            gider.GiderKategori = p.GiderKategori;
            gider.GiderTl = p.GiderTl;
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            gider.GiderKategori = ktg.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}