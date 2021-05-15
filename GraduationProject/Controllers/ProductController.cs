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
            CartViewModel order;
            Product product = db.Products.FirstOrDefault(p => p.ID == id);
            product.OrderDetailsCost = product.Cost;
            if(Session["order"] != null)
            {
               order = Session["order"] as CartViewModel;
               order.ProductsWithQuantity.Add(new ProductWithQuantityViewModel() {Product = product, Quantity=1});
                if(order.Coupon !=null)
                product.OrderDetailsCost = (float)Math.Round(product.Cost * order.Coupon.Discount,2);
                order.TotalPrice += product.OrderDetailsCost;
                order.totalQuantity++;
            }
            else
            {
                order = new CartViewModel();
                order.totalQuantity = 1;
                order.TotalPrice = product.OrderDetailsCost;
                order.ProductsWithQuantity = new List<ProductWithQuantityViewModel>();
                order.ProductsWithQuantity.Add(new ProductWithQuantityViewModel() { Product = product, Quantity = 1 });
            }
            order.TotalPrice = (float)Math.Round(order.TotalPrice, 2);
            Session["order"] = order;
        }
    }
}