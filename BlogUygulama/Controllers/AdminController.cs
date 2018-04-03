using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogUygulama.Models;


namespace BlogUygulama.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        mvcblogDB db = new mvcblogDB();
        public ActionResult Index()
        {
            ViewBag.makaleSayisi = db.Makales.Count();
            ViewBag.kategoriSayisi = db.Kategoris.Count();
            return View();
        }
    }
}