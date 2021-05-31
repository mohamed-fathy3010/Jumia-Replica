using GraduationProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    [Authorize(Roles = "customer")]
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        
        public ActionResult Index()
        {
            return View("~/Views/Cart/cart.cshtml");
        }
        [HttpPost]
        public ActionResult Buy()
        {
            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ID == userId);
            CartViewModel cart = Session["order"] as CartViewModel;
            Coupon coupon = cart.Coupon;
            DateTime date = DateTime.Now;
            Order order = new Order()
            {
                Status = OrderStatus.Awaiting,
                Date = date,
                Address = customer.Address,
                Freught = 50,
                CustomerID = userId,
                CouponCode = coupon?.Code
            };
            db.Orders.Add(order);
                foreach(var pair in cart.ProductsWithQuantity)
                { 
                for(int i = 0;i< pair.Quantity;i++)
                {
                    OrderDetails orderDetails = new OrderDetails()
                    {
                        ProductID = pair.Product.ID,
                        UnitPrice = pair.Product.OrderDetailsCost,
                        OrderID = order.ID,
                        OrderDate = order.Date,
                        Status = OrderDetailsStatus.awaiting
                    };
                    db.OrderDetails.Add(orderDetails);
                }
                }
            db.SaveChanges();
            Session.Remove("order");
            return RedirectToAction("index","home");
        }
        [HttpPost]
        public ActionResult Apply(string code)
        {
            Coupon coupon = db.Coupons.FirstOrDefault(c => c.Code == code);
            if(coupon != null)
            {
                string customerId = User.Identity.GetUserId();
                if (db.Orders.Any(o => o.CustomerID == customerId && o.CouponCode == code))
                {
                    ViewBag.error = "you have already used this code";
                    return View("~/Views/Cart/cart.cshtml");
                }
                float totalPrice = 0;
                CartViewModel order = Session["order"] as CartViewModel;
                order.Coupon = coupon;
                foreach (var item in order.ProductsWithQuantity)
                {
                    item.Product.OrderDetailsCost = (float)Math.Round(item.Product.Cost * (1 - coupon.Discount), 2);
                    totalPrice += item.Product.OrderDetailsCost * item.Quantity;
                }
                order.TotalPrice = (float)Math.Round(totalPrice,2);
                Session["order"] = order;
            }
            else
            {
                ViewBag.error = "wrong coupon code";
            }
            return View("~/Views/Cart/cart.cshtml");
        }
        [HttpPost]
        public ActionResult ChangeQuantity(int changedId,int changedQuantity)
        {
            int totalQuantity = 0;
            float totalPrice = 0;
            CartViewModel order = Session["order"] as CartViewModel;
            order.ProductsWithQuantity[changedId].Quantity = changedQuantity;
            foreach(var item in order.ProductsWithQuantity)
            {
                totalQuantity += item.Quantity;
                totalPrice += item.Product.OrderDetailsCost * item.Quantity;
            }
            order.totalQuantity = totalQuantity;
            order.TotalPrice = totalPrice;
            Session["order"] = order;
            return View("~/Views/Cart/cart.cshtml");
        }
        [Authorize(Roles = "customer")]
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            CartViewModel cart = Session["order"] as CartViewModel;
            ProductWithQuantityViewModel product = cart.ProductsWithQuantity.Where(p => p.Product.ID == id).FirstOrDefault();
            cart.totalQuantity -= product.Quantity;
            cart.TotalPrice = cart.TotalPrice - (product.Quantity * product.Product.OrderDetailsCost);
            cart.ProductsWithQuantity.Remove(product);
            Session["order"] = cart;
            return RedirectToAction("Index");

        }
    }
}