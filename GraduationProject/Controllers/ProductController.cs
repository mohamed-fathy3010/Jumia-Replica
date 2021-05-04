using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [Route("products/{id}")]
        public ActionResult Index(int id)
        {
            return View("~/Views/Product/ProductDetails.cshtml");
        }
    }
}