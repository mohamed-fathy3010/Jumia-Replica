using GraduationProject.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GraduationProject.Controllers
{
    public class SellerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Seller
        public ActionResult Index()
        {
            return View();
        }

        [Route("financials/account-summary")]
        public ActionResult AccountSummary()
        {
            return View("~/Views/Seller/Financials/AccountSummary.cshtml");
        }
        public ActionResult InventoryManagement()
        {
            string userId = User.Identity.GetUserId();
            var sellerProducts = db.Products.Where(x => x.InventoryId == userId).ToList();
            return View("~/Views/Seller/Inventory/InventoryManagement.cshtml", sellerProducts);
        }
        public ActionResult StartListing()
        {
            return RedirectToAction("create", "product");
        }
        public ActionResult ProductPage()
        {
            return View("~/views/Product/ProductPage.cshtml");

        }

        public ActionResult ReturnManagement()
        {
            return View("~/views/seller/orders/ReturnManagement.cshtml");

        }
        public ActionResult CanceledOrders()
        {
            return View("~/views/seller/orders/CanceledOrders.cshtml");

        }


        public ActionResult OrderManagement(string tab)
        {
            string user_id = User.Identity.GetUserId();
            var allOrderDetails = db.OrderDetails.OrderByDescending(o => o.OrderDate).Include(s => s.Product.Category).Where(d =>d.Product.InventoryId == user_id).ToList();
            return View("~/Views/Seller/Orders/OrderManagement.cshtml", allOrderDetails);
        }
        public ActionResult FeedBack()
        {
            return View("~/Views/seller/Feedback.cshtml");
        }
        public ActionResult ComplaintsManagement()
        {
            return View("~/Views/seller/PostDelivery/ComplaintsManagement.cshtml");
        }
        public ActionResult Awaiting()
        {
            string user_id = User.Identity.GetUserId();
            var allOrderDetails = db.OrderDetails.Where(o => o.Status == OrderDetailsStatus.awaiting).OrderByDescending(o => o.OrderDate).Include(s => s.Product.Category).Where(d => d.Product.InventoryId == user_id).ToList();
            return PartialView("~/Views/Seller/Orders/AwaitingTabPartialView.cshtml", allOrderDetails);
        }
        public ActionResult Confirmed()
        {
            string user_id = User.Identity.GetUserId();
            var allOrderDetails = db.OrderDetails.Where(o => o.Status == OrderDetailsStatus.confirmed).OrderByDescending(o => o.OrderDate).Include(s => s.Product.Category).Where(d => d.Product.InventoryId == user_id).ToList();
            return PartialView("~/Views/Seller/Orders/ConfirmedTabPartialView.cshtml", allOrderDetails);
        }
        public ActionResult Shipped()
        {
            string user_id = User.Identity.GetUserId();
            var allOrderDetails = db.OrderDetails.Where(o => o.Status == OrderDetailsStatus.shipped).OrderByDescending(o => o.OrderDate).Include(s => s.Product.Category).Where(d => d.Product.InventoryId == user_id).ToList();
            return PartialView("~/Views/Seller/Orders/ShippedTabPartialView.cshtml", allOrderDetails);
        }
        public ActionResult Delivered()
        {
            string user_id = User.Identity.GetUserId();
            var allOrderDetails = db.OrderDetails.Where(o => o.Status == OrderDetailsStatus.delivered).OrderByDescending(o => o.OrderDate).Include(s => s.Product.Category).Where(d => d.Product.InventoryId == user_id).ToList();
            return PartialView("~/Views/Seller/Orders/DeliveredTabPartialView.cshtml", allOrderDetails);
        }
        public ActionResult ConfirmSelected(Dictionary<string, bool> orderDetails, string confirm, string cancel)
        {
            foreach (KeyValuePair<string, bool> item in orderDetails)
            {
                if (item.Value == true)
                {
                    int id = int.Parse(item.Key);
                    OrderDetails currentOrderDetails = db.OrderDetails.FirstOrDefault(o => o.ID == id);
                    if (confirm != null)
                    {
                        currentOrderDetails.Status = OrderDetailsStatus.confirmed;
                        currentOrderDetails.ConfirmedDate = DateTime.Now;
                    }
                    else
                    {
                        currentOrderDetails.Status = OrderDetailsStatus.canceled;
                        currentOrderDetails.CanceledDate = DateTime.Now;
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("OrderManagement");
        }
        public ActionResult ShipSelected(Dictionary<string, bool> orderDetails)
        {
            foreach (KeyValuePair<string, bool> item in orderDetails)
            {
                if (item.Value == true)
                {
                    int id = int.Parse(item.Key);
                    OrderDetails currentOrderDetails = db.OrderDetails.FirstOrDefault(s => s.ID == id);
                    currentOrderDetails.Status = OrderDetailsStatus.shipped;
                    currentOrderDetails.ShippedDate = DateTime.Now;
                }
            }
            db.SaveChanges();
            return RedirectToAction("OrderManagement");
        }
        public ActionResult DeliverSelected(Dictionary<string, bool> orderDetails)
        {
            foreach (KeyValuePair<string, bool> item in orderDetails)
            {
                if (item.Value == true)
                {
                    int id = int.Parse(item.Key);
                    OrderDetails currentOrderDetails = db.OrderDetails.FirstOrDefault(s => s.ID == id);
                    currentOrderDetails.Status = OrderDetailsStatus.delivered;
                    currentOrderDetails.DeliveredDate = DateTime.Now;
                }
            }
            db.SaveChanges();
            return RedirectToAction("OrderManagement");
        }

        public ActionResult FeeDiscounts()
        {
            return View("~/Views/Seller/FeeDiscounts/FeeDiscounts.cshtml");
        }

        public ActionResult Dashbored()
        {
            return View("~/Views/Seller/Dashbored/Dashbored.cshtml");
        }
    }
   
}

