using SiteYonetimi.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteYonetimi.Controllers
{
    public class AidatController : Controller
    {
        // GET: Aidat

        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();

        public ActionResult Index(string p)
        {
            var toplamGelir = (from emp in db.TBL_Gelir select emp.GelirTl).Sum();
            var toplamGider = (from emp in db.TBL_Gider select emp.GiderTl).Sum();
            var Total = toplamGelir - toplamGider;
            var DaireSayisi =  db.TBL_Daireler.Count();

            var TotalOne = toplamGider / DaireSayisi;

            ViewBag.sumgelir = toplamGelir;
            ViewBag.sumgider = toplamGider;
            ViewBag.TotalOne = TotalOne;
            ViewBag.total = Total;

            var aidatlar = from k in db.TBL_Aidat select k;
            if (!string.IsNullOrEmpty(p))
            {
                //  gelirler = gelirler.Aggregate((a, b) => a + b);
                //kitaplar = kitaplar.Where(x => x.AD.Contains(p));
                aidatlar = aidatlar.Where(x => x.AidatAd.Contains(p));
            }

            return View(aidatlar.ToList());
        }
        [HttpGet]

        public ActionResult AidatEkle()
        {
            List<SelectListItem>
           deger1 = (from i in db.TBL_KATEGORI.ToList()
                     select new SelectListItem
                     { Text = i.AD, Value = i.ID.ToString() }).ToList();
           // SelectListItem
           //deger2 = (from i in db.TBL_Daireler.ToList()
           //          select new SelectListItem
           //          { Text = i.DaireNo, Value = i.ID.ToString() }).ToList();
           //List<SelectListItem> deger2 = (from x in db.TBL_Daireler.ToList() select new SelectListItem { Text = x.BlokAd +"Daire No="x.DaireNo + , Value = x.ID.ToString() }).ToList();


            ViewBag.dgr1 = deger1;
            //ViewBag.dgr2 = deger2;
            var toplamGelir = (from emp in db.TBL_Gelir select emp.GelirTl).Sum();
            var toplamGider = (from emp in db.TBL_Gider select emp.GiderTl).Sum();
            var Total = toplamGelir - toplamGider;
            var DaireSayisi = db.TBL_Daireler.Count();
            var TotalOne = toplamGider / DaireSayisi;
            ViewBag.toplamGelir = toplamGelir;
            ViewBag.toplamGider = toplamGider;
            ViewBag.Total = Total;
            ViewBag.DaireSayisi = DaireSayisi;
            ViewBag.TotalOne = TotalOne;



            return View();
        }
        [HttpPost]
        public ActionResult AidatEkle(TBL_Aidat p)
        {
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            p.TBL_KATEGORI = ktg;
            TBL_Gelir gelr = new TBL_Gelir();
            gelr.GelirAd = "Aidat";
            gelr.İD = p.İD;
            gelr.GelirTl = p.Ödenecek;
            gelr.GelirBilgi = p.İD + "no'lu aidat fisi";
            gelr.Kategori = p.TBL_KATEGORI.ID;
            db.TBL_Gelir.Add(gelr);
            db.TBL_Aidat.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AidatSil(int id)
        {
            var Aidat = db.TBL_Aidat.Find(id);
            db.TBL_Aidat.Remove(Aidat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AidatGetir(int id)
        {
            var gdr = db.TBL_Gelir.Find(id);
            var Aidat = db.TBL_Aidat.Find(id);

            List<SelectListItem>
         deger1 = (from i in db.TBL_KATEGORI.ToList()
                   select new SelectListItem
                   { Text = i.AD, Value = i.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;


            return View("AidatGetir", gdr);
        }
        public ActionResult AidatGuncelle(TBL_Aidat p)
        {

            var gelir = db.TBL_Gelir.Find(p.İD);
            var Aidat = db.TBL_Aidat.Find(p.İD);
            Aidat.DaireİD = p.DaireİD;
            Aidat.AidatAd = p.AidatAd;
            Aidat.Kategori = p.Kategori;
            Aidat.Alındı = p.Alındı;
            Aidat.OdenenTarih = p.OdenenTarih;
            var ktg = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            Aidat.Kategori = ktg.ID;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}