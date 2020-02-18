using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        BlogDB db = new BlogDB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult Login()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Login(Kullanici model)
        {

            try
            {
                var varmi = db.Kullanicis.Where(i => i.KullaniciAdi == model.KullaniciAdi).SingleOrDefault();
                if (varmi == null)
                {
                    return View();
                }

                if (varmi.Sifre == model.Sifre)
                {
                    Session["username"] = varmi.KullaniciAdi;
                    return RedirectToAction("Index","Kullanici");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        [HttpPost]
        public ActionResult Create(Kullanici model)
        {
            try
            {
                var varmi = db.Kullanicis.Where(i => i.KullaniciAdi == model.KullaniciAdi).SingleOrDefault();

                if (varmi != null)
                {
                    return View();
                }

                if (string.IsNullOrEmpty(model.Sifre))
                {
                    return View();
                }

                model.KayıtTarihi = DateTime.Now;
                model.YetkiId = 1;
                db.Kullanicis.Add(model);
                db.SaveChanges();
                Session["username"] = model.KullaniciAdi;
                return RedirectToAction("Index", "Kullanici");
            }
            catch
            {
                return View();
            }
        }
    }
}