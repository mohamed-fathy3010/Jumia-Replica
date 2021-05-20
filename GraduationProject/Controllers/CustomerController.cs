using GraduationProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}