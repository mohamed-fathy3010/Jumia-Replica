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
        public ActionResult Buy(IEnumerable<ProductWithQuantityViewModel> cart)
        {
            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ID == userId);

            DateTime date = DateTime.Now;
            Order order = new Order()
            {
                Status = OrderStatus.Awaiting,
                Date = date,
                Address = customer.Address,
                Freught = 50,
                CustomerID = userId
            };
            db.Orders.Add(order);
                foreach(var pair in cart)
                {
                Product product = db.Products.FirstOrDefault(p => p.ID == pair.Id);
                for(int i = 0;i< pair.Quantity;i++)
                {
                    OrderDetails orderDetails = new OrderDetails()
                    {
                        ProductID = pair.Id,
                        UnitPrice = product.Cost,
                        OrderID = order.ID,
                        OrderDate = order.Date,
                        Status = OrderDetailsStatus.awaiting
                    };
                    db.OrderDetails.Add(orderDetails);
                }
                }
            db.SaveChanges();
            return RedirectToAction("index","home");
        }
    }
}