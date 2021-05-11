using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    public class SellerController : Controller
    {
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

        //[Route("FeeDiscounts/FeeDiscounts")]
        //public ActionResult FeeDiscounts()
        //{
        //    return View("~/Views/Seller/FeeDiscounts/FeeDiscounts.cshtml");
        //}
    }

}