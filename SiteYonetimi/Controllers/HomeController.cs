using SiteYonetimi.Models.Entitiy;
using SiteYonetimi.Models.Siniflarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteYonetimi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBL_KITAP.ToList();
            cs.Deger2 = db.TBL_HAKKIMIZDA.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBL_ILETISIM t)
        {
            db.TBL_ILETISIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}