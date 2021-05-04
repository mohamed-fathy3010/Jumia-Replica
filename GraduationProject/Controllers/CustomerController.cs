using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Account()
        {
            return View("~/Views/Account/Customer/Account.cshtml");
        }
        [Route("customer/account/edit")]
        public ActionResult AccountEdit()
        {
            return View("~/Views/Account/Customer/AccountEdit.cshtml");
        }
    }
}