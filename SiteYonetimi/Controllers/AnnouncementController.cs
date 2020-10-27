﻿using SiteYonetimi.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteYonetimi.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();
        public ActionResult Index()
        {
            var degerler = db.TBL_DUYURULAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(TBL_DUYURULAR t)
        {
            db.TBL_DUYURULAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyurusil = db.TBL_DUYURULAR.Find(id);
            db.TBL_DUYURULAR.Remove(duyurusil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(TBL_DUYURULAR p)
        {
            var duyuru = db.TBL_DUYURULAR.Find(p.ID);

            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGuncelle(TBL_DUYURULAR t)
        {
            var duyuru = db.TBL_DUYURULAR.Find(t.ID);
            duyuru.KATEGORI = t.KATEGORI;
            duyuru.ICERIK = t.ICERIK;
            duyuru.TARIH = t.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}