using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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
                product.OrderDetailsCost = (float)Math.Round(product.Cost * (1 - order.Coupon.Discount),2);
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



        public ViewResult Search(string Searching, string filtering)
        {
            string price = Request.QueryString["price"];
            string rate = Request.QueryString["rate"];
            var SearchProduct = db.Products.Where(p => p.Name.Contains(Searching)).ToList();
            foreach (var product in SearchProduct)
            {
                var orderDetails = db.OrderDetails.Where(o => o.ProductID == product.ID);
                var averageRating = orderDetails.Include(o => o.FeedBack).Where(o => o.FeedBack != null).ToList();
                Decimal average = 0;
                foreach (var details in averageRating)
                {
                    average += details.FeedBack.Rate;
                }
                average /= averageRating.Count;
                product.Rate = average;
            }
           
           
            if(price != null)
            {
                if(price == "asc")
                {
                    SearchProduct = SearchProduct.OrderBy(p => p.Cost).ToList();
                }
                else
                {
                    SearchProduct = SearchProduct.OrderByDescending(p => p.Cost).ToList();
                }
            }
           if( rate != null)
            {
                if( rate == "asc")
                {
                    SearchProduct = SearchProduct.OrderBy(p => p.Rate).ToList();
                }
                else
                {
                    SearchProduct = SearchProduct.OrderByDescending(p => p.Rate).ToList();

                }
            }
            return View(SearchProduct);
        }
    }
}