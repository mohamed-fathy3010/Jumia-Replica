using GraduationProject.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult OrderManagement(string tab)
        {
            var allOrderDetails = db.OrderDetails.OrderByDescending(o => o.OrderDate).Include(s => s.Product.Category).ToList();
            return View("~/Views/Seller/Orders/OrderManagement.cshtml",allOrderDetails);
        }
        public ActionResult Awaiting()
        {
            var allOrderDetails = db.OrderDetails.Where(o => o.Status == OrderDetailsStatus.awaiting).OrderByDescending(o => o.OrderDate).Include(s => s.Product.Category).ToList();
            return PartialView("~/Views/Seller/Orders/AwaitingTabPartialView.cshtml", allOrderDetails);
        }
        public ActionResult Confirmed()
        {
            var allOrderDetails = db.OrderDetails.Where(o => o.Status == OrderDetailsStatus.confirmed).OrderByDescending(o => o.OrderDate).Include(s => s.Product.Category).ToList();
            return PartialView("~/Views/Seller/Orders/ConfirmedTabPartialView.cshtml", allOrderDetails);
        }
        public ActionResult Shipped()
        {
            var allOrderDetails = db.OrderDetails.Where(o => o.Status == OrderDetailsStatus.shipped).OrderByDescending(o => o.OrderDate).Include(s => s.Product.Category).ToList();
            return PartialView("~/Views/Seller/Orders/ShippedTabPartialView.cshtml", allOrderDetails);
        }
        public ActionResult Delivered()
        {
            var allOrderDetails = db.OrderDetails.Where(o => o.Status == OrderDetailsStatus.delivered).OrderByDescending(o => o.OrderDate).Include(s => s.Product.Category).ToList();
            return PartialView("~/Views/Seller/Orders/DeliveredTabPartialView.cshtml", allOrderDetails);
        }
        public ActionResult ConfirmSelected(Dictionary<string,bool> orderDetails,string confirm,string cancel)
        {
            foreach (KeyValuePair<string,bool> item in orderDetails)
            {
                if(item.Value == true)
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
        public ActionResult ShipSelected(Dictionary<string,bool> orderDetails)
        {
            foreach (KeyValuePair<string,bool> item in orderDetails)
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
    }   
}