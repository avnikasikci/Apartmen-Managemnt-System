using SiteYonetimi.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteYonetimi.Controllers
{
    public class StatisticsController : Controller
    {
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();

        // GET: Statistics
        public ActionResult Index()
        {
            var deger1 = db.TBL_UYELER.Count();
            var deger2 = db.TBL_KITAP.Count();
            var deger3 = db.TBL_KITAP.Where(x => x.DURUM == false).Count();
            var deger4 = db.TBL_CEZALAR.Sum(x => x.PARA);
            var toplamGelir = (from emp in db.TBL_Gelir select emp.GelirTl).Sum();
            var toplamGider = (from emp in db.TBL_Gider select emp.GiderTl).Sum();
            var Total = toplamGelir - toplamGider;
            var DaireSayisi = db.TBL_Daireler.Count();
            var TotalOne = toplamGider / DaireSayisi;



            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.toplamGelir = toplamGelir;
            ViewBag.toplamGider = toplamGider;
            ViewBag.Total = Total;
            ViewBag.DaireSayisi = DaireSayisi;
            ViewBag.TotalOne = TotalOne;




    







            return View();
        }
        public ActionResult Weater()
        {
            return View();
        }
        public ActionResult HavaDurumu()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase resim)
        {
            if (resim.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(resim.FileName));
                resim.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }
    }
}