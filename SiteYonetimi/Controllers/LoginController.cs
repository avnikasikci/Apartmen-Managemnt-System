using SiteYonetimi.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SiteYonetimi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBL_UYELER p)
        {
            TBL_UYELER user = db.TBL_UYELER.AsNoTracking().FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            var bilgiler = db.TBL_UYELER.AsNoTracking().FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                Session["Login"] = bilgiler;
                //TempData["id"] = bilgiler.ID.ToString();
                //TempData["Ad"] = bilgiler.AD.ToString();
                //TempData["Soyad"] = bilgiler.SOYAD.ToString();
                //TempData["KullanıcıAdı"] = bilgiler.KULLANICIADI.ToString();
                //TempData["Sifre"] = bilgiler.SIFRE.ToString();
                //TempData["Okul"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index", "Panel");

            }
            else
            {
                return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index");
        }
    }
}