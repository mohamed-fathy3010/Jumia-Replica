using graduation_project;
using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{

    public class ProductController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Product
        [Route("products/{id}")]
        public ActionResult Index(int id)
        {
            return View("~/Views/Product/ProductDetails.cshtml");
        }

        [HttpPost,Route("products/{id}")]
        public void AddToCart(int id)
        {
            List<Product> order;
            Product product = db.Products.FirstOrDefault(p => p.ID == id);
            if(Session["order"] != null)
            {
               order = Session["order"] as List<Product> ;
               order.Add(product);
            }
            else
            {
                order = new List<Product>();
                order.Add(product);
            }
            Session["order"] =order;
        }
    }
}