using BlogSite.Helpers;
using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class KullaniciController : YetkiliController
    {
        BlogDB db = new BlogDB();

        // GET: Kullanici
        public ActionResult Index()
        {
            string kullaniciadi = Session["username"].ToString();
            var kullanici = db.Kullanicis.Where(i => i.KullaniciAdi == kullaniciadi).SingleOrDefault();

            return View(kullanici);
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(int id)
        {
            var kisi = db.Kullanicis.Where(i => i.Id == id).SingleOrDefault();
            return View(kisi);
        }

        public ActionResult Profil()
        {
            string kullaniciadi = Session["username"].ToString();
            var kisi = db.Kullanicis.Where(i => i.KullaniciAdi == kullaniciadi).SingleOrDefault();
            return View(kisi);
        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: Kullanici/Edit/5
        public ActionResult Edit(int id)
        {
            string kullaniciadi = Session["username"].ToString();
            var user = db.Kullanicis.Where(i => i.KullaniciAdi == kullaniciadi).SingleOrDefault();
            if (OrtakSinif.EditIzinYetkiVarmi(id,user))
            {
                var kisi = db.Kullanicis.Where(i => i.Id == id).SingleOrDefault();
                return View(kisi);
            }
            return HttpNotFound();
        }

        // POST: Kullanici/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Kullanici model)
        {
            try
            {
                var kisi = db.Kullanicis.Where(i => i.Id == id).SingleOrDefault();
                kisi.Isim = model.Isim;
                kisi.Soyisim = model.Soyisim;
                kisi.Sifre = model.Sifre;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanici/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kullanici/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
