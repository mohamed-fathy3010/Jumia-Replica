using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GraduationProject.Controllers
{
    [Authorize(Roles = "customer")]
    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer

        public ActionResult Account()
        {
            string UserId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ID == UserId);
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customer = customer;
            customerViewModel.Fname = customer.ApplicationUser.FirstName;
            customerViewModel.Lname = customer.ApplicationUser.LastName;
            customerViewModel.Email = customer.ApplicationUser.Email;
            return View("~/Views/Account/Customer/Account.cshtml", customerViewModel);
        }


        [Route("customer/account/edit")]
        public ActionResult AccountEdit()
        {

            // Fetch the customerprofile
            string UserId = User.Identity.GetUserId();
            Customer customer = db.Customers.FirstOrDefault(c => c.ID == UserId);

            // Construct the viewmodel
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customer = customer;
            customerViewModel.Fname = customer.ApplicationUser.FirstName;
            customerViewModel.Lname = customer.ApplicationUser.LastName;
            customerViewModel.Email = customer.ApplicationUser.Email;
            customerViewModel.PhoneNumber = customer.ApplicationUser.PhoneNumber;
            customerViewModel.Date = customer.Date;
            return View("~/Views/Account/Customer/AccountEdit.cshtml", customerViewModel);
        }
        [HttpPost]


        public ActionResult Edit(CustomerViewModel Customer)

        {

            if (ModelState.IsValid)
            {
                string UserId = User.Identity.GetUserId();
                Customer customer = db.Customers.FirstOrDefault(c => c.ID == UserId);
                // Update fields
                customer.ApplicationUser.FirstName = Customer.Fname;
                customer.ApplicationUser.LastName = Customer.Lname;
                customer.ApplicationUser.PhoneNumber = Customer.PhoneNumber;
                customer.Date = Customer.Date;
                customer.Gender = Customer.Customer.Gender;
                //db.Entry(customerViewModel).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Account");
            }

            return RedirectToAction("AccountEdit");

        }

        public ActionResult history()
        {
            string userId = User.Identity.GetUserId();
            //get all orders for current authenticated customer that has delivered order details
            var order = db.Orders.Include(o => o.OrderDetails)
                .Where(d => d.OrderDetails.Any(s => s.Status == OrderDetailsStatus.delivered) && d.CustomerID == userId)
                .ToList();
            // for each order get only the delivered order details.
            foreach (var item in order)
            {
                item.OrderDetails = item.OrderDetails.Where(o => o.Status == OrderDetailsStatus.delivered).ToList();
            }
            return View();
        }

        public ActionResult OrderHistory()
        {
            string userId = User.Identity.GetUserId();

            var user = db.Users.FirstOrDefault(l => l.Id == userId);

            //get all orders for current authenticated customer that has delivered order details
            //var orderDetails = db.OrderDetails
            //    .Include(o => o.Order)
            //    .Include(o => o.Product.Inventory.SellerInfo)
            //    .Where(o => o.Status == OrderDetailsStatus.delivered && o.Order.CustomerID == userId)
            //    .GroupBy(o => o.ProductID).ToList();
            var order = db.Orders.Include("OrderDetails.Product.Inventory.SellerInfo")
                .Include("OrderDetails.FeedBack")
                .Where(d => d.OrderDetails.Any(s => s.Status == OrderDetailsStatus.delivered) && d.CustomerID == userId)
                .ToList();
                foreach (var item in order)
                {
                    item.OrderDetails = item.OrderDetails.Where(o => o.Status == OrderDetailsStatus.delivered).ToList();
                }
            return View("~/views/Orders/Orders.cshtml", order);
        }
        [Authorize(Roles ="customer")]
        public ActionResult SavedItems()
        {
            string userId = User.Identity.GetUserId();
            List<Product> products;
            var productsWished = db.ProductWishlists.Include(p => p.Product).Where(p => p.wishListId == userId).ToList();
            products = productsWished.Select(p => p.Product).ToList();

                return View("~/views/Customer/SavedItems.cshtml",products);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Rate()
        {
            int id = int.Parse(Request["id"]);
            var feedBack = db.FeedBacks.FirstOrDefault(a => a.ID == id);
            int rate = int.Parse(Request["rate"]);
            string positive = Request["positive"];
            string negative = Request["negative"];
            if(feedBack == null)
            {
                db.FeedBacks.Add(new FeedBack() {ID = id, Rate = rate, PositiveComment = positive, NegativeComment = negative});
            }
            db.SaveChanges();
            return RedirectToAction("OrderHistory");
        }
    }
}
