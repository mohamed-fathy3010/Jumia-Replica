using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace GraduationProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            HomeViewModel home = new HomeViewModel();
            home.HotSale = db.Products.OrderBy(r => Guid.NewGuid()).Take(6).ToList();
            home.Laptops = db.Products.OrderBy(r => Guid.NewGuid())
                .Include(p => p.Category)
                .Where(p => p.Category.Name == "Laptop")
                .Take(12).ToList();
            home.SmartPhones = db.Products.OrderBy(r => Guid.NewGuid())
               .Include(p => p.Category)
               .Where(p => p.Category.Name == "Smartphone")
               .Take(6).ToList();
            return View("Index",home);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}