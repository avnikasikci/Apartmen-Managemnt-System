using SiteYonetimi.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteYonetimi.Controllers
{
    public class HesapKesimController : Controller
    {
        // GET: HesapKesim
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKET.Where(x => x.ISLEMDURUM == false).ToList();

            var aidatlar = db.TBL_Aidat.Where(x => x.Alındı == false).ToList();
            return View(aidatlar);
        }
        [HttpGet]
        public ActionResult AidatGiris()
        {
            List<SelectListItem> deger1 = (from x in db.TBL_UYELER.ToList() select new SelectListItem { Text = x.AD + " " + x.SOYAD, Value = x.ID.ToString() }).ToList();
            List<SelectListItem> deger2 = (from y in db.TBL_Aidat.Where(x => x.Alındı == true).ToList() select new SelectListItem { Text = y.AidatAd, Value = y.İD.ToString() }).ToList();

            List<SelectListItem> deger3 = (from z in db.TBL_PERSONEL.ToList() select new SelectListItem { Text = z.PERSONEL, Value = z.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult AidatGiris(TBL_Aidat p)
        {
            var d1 = db.TBL_UYELER.Where(x => x.ID == p.TBL_UYELER.ID).FirstOrDefault();
            var d2 = db.TBL_Aidat.Where(x => x.İD == p.İD).FirstOrDefault();
            // var d3 = db.TBL_PERSONEL.Where(z => z.ID == p.TBL_PERSONEL.ID).FirstOrDefault();
            p.TBL_UYELER = d1;
            // p.TBL_PERSONEL = d3;
            db.TBL_Aidat.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult AidatCikis(TBL_Aidat p)
        {
            var odn = db.TBL_Aidat.Find(p.İD);
            DateTime d1 = DateTime.Parse(odn.SonÖdeme.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Odunciade", odn);
        }
        public ActionResult AidatGuncelle(TBL_Aidat p)
        {
            var hrk = db.TBL_Aidat.Find(p.İD);
            hrk.OdenenTarih = p.OdenenTarih;
            hrk.Alındı = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}