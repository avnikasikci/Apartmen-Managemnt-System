using SiteYonetimi.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SiteYonetimi.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();

        [HttpGet]
       // [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBL_UYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.OKUL = p.OKUL;
            uye.SOYAD = p.SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Duyurular()
        {
            var duyuruListesi = db.TBL_DUYURULAR.ToList();


            return View(duyuruListesi);

        }
        public ActionResult AidatBilgileri(string p)
        {
            var toplamGelir = (from emp in db.TBL_Gelir select emp.GelirTl).Sum();
            var toplamGider = (from emp in db.TBL_Gider select emp.GiderTl).Sum();
            var Total = toplamGelir - toplamGider;
            var DaireSayisi = db.TBL_Daireler.Count();

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


        public ActionResult AidatOde(TBL_Aidat p)
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
            return RedirectToAction("AidatBilgileri");
        }
        public ActionResult Borclar()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBL_UYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBL_HAREKET.Where(x => x.UYE == id).ToList();

            return View(degerler);

        }



        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();


            return RedirectToAction("GirisYap", "uye");

        }
    }
}