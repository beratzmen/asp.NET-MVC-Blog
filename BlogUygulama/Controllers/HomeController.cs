using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogUygulama.Models;
using PagedList.Mvc;
using PagedList;

namespace BlogUygulama.Controllers
{
    public class HomeController : Controller
    {
        mvcblogDB db = new mvcblogDB();

        // GET: Home
        
        public ActionResult Index(int Page=1)
        {
            var makale = db.Makales.OrderByDescending(m => m.MakaleId).ToPagedList(Page,5);
            return View(makale);
        }


        public ActionResult BlogAra(string Ara=null)
        {
            var aranan = db.Makales.Where(m => m.Baslik.Contains(Ara)).ToList();
            return View(aranan.OrderByDescending(m=>m.Tarih));
        }



        public ActionResult KategoriMakale(int id)
        {
            var makaleler = db.Makales.Where(m => m.Kategori.KategoriId == id).ToList();
            return View(makaleler);
        }



        public ActionResult OkunmaArttir(int Makaleid)
        {
            var makale = db.Makales.Where(m => m.MakaleId == Makaleid).SingleOrDefault();
            makale.Okunma += 1;
            db.SaveChanges();
            return View();
        }

        public ActionResult MakaleDetay(int id)
        {
            var makale = db.Makales.Where(m => m.MakaleId ==id ).SingleOrDefault();
            if (makale==null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }
        
        public ActionResult Hakkımızda()
        {
            return View();
        }
        
        public ActionResult Iletisim()
        {
            return View();
        }
        
        public ActionResult Kategori()
        {
           
            
            return View( db.Kategoris.ToList());
          
        }
      

      
    }
}