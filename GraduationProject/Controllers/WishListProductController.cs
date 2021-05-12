using graduation_project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GraduationProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace GraduationProject.Controllers
{
    public class WishListProductController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: WishListProduct
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _Fav(int ID)
        {
            List<string> errors = new List<string>(); // You might want to return an error if something wrong happened

            //Do DB Processing   
            var ProductId = db.Products.FirstOrDefault(p => p.ID == ID).ID;
            var userId = User.Identity.GetUserId();
            var savedProductWishList = db.CustomerProducts.Add(new CustomerProduct() { CustomerID = userId, ProductID = ProductId });
           var success= db.SaveChanges();
            if (success>0)
            {

            return Json("product added to wishlist successfully", JsonRequestBehavior.AllowGet);

            }
            return Json(errors, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult _UnFav(int ID)
        {
            List<string> errors = new List<string>(); // You might want to return an error if something wrong happened
            //Do DB Processing   
            var unsavedProduct = db.CustomerProducts.FirstOrDefault(p => p.ProductID == ID);
            db.CustomerProducts.Remove(unsavedProduct);
            db.SaveChanges();

            return Json(errors, JsonRequestBehavior.AllowGet);
        }
    }

}