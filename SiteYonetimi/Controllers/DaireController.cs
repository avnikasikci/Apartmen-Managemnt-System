using SiteYonetimi.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteYonetimi.Controllers
{
    public class DaireController : Controller
    {
        // GET: Daire
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();

        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBL_KITAP select k;
            var daireler = from k in db.TBL_Daireler select k;

            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.AD.Contains(p));
                daireler = daireler.Where(x => x.BlokAd.Contains(p));
            }
            //var kitaplar = db.TBL_KITAP.ToList();
            return View(daireler.ToList());
        }
    }
}