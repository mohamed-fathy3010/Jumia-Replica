using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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
            customerViewModel.Fname = customer.ApplicationUser.FirstName;
            customerViewModel.Lname = customer.ApplicationUser.LastName;
            customerViewModel.Email = customer.ApplicationUser.Email;
            customerViewModel.PhoneNumber = customer.ApplicationUser.PhoneNumber;
            return View("~/Views/Account/Customer/AccountEdit.cshtml", customerViewModel);
        }
        [HttpPost]
        public ActionResult AccountEdit(CustomerViewModel Customer)
        {

            if (ModelState.IsValid)
            {
                string UserId = User.Identity.GetUserId();
                Customer customer = db.Customers.FirstOrDefault(c => c.ID == UserId);

                // Update fields
                CustomerViewModel customerViewModel = new CustomerViewModel();
                customer.ApplicationUser.FirstName = customerViewModel.Fname;
                customer.ApplicationUser.LastName = customerViewModel.Lname;
                customer.ApplicationUser.Email = customerViewModel.Email;
                customer.ApplicationUser.PhoneNumber = customerViewModel.PhoneNumber;

                //db.Entry(customerViewModel).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Account");
            }

            return View(Customer);
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
        [AllowAnonymous]
        public ActionResult OrderHistory()
        {
            string userId = User.Identity.GetUserId();

            var user = db.Users.FirstOrDefault(l => l.Id == userId);

            //get all orders for current authenticated customer that has delivered order details
            var order = db.Orders.Include(o => o.OrderDetails)
                .Where(d => d.OrderDetails.Any(s => s.Status == OrderDetailsStatus.completed) && d.CustomerID == userId)
                .ToList();

            //var order = db.Customers.Where(h => h.ID == ID).Select(c => c.Orders.Any(o => o.OrderDetails.Any(k => k.Status == OrderDetailsStatus.completed))).ToList();

            if (order == null)
            {
                return View("~/views/customer/orderhistoryempty.cshtml");
            }
            return View(order);
        }
    }
}