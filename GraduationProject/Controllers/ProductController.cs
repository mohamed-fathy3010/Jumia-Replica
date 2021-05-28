using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Net;

namespace GraduationProject.Controllers
{

    public class ProductController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index(int id)
        {
            Product product = db.Products
                .Include(p => p.Albums)
                .Include("OrderDetails.FeedBack")
                .Include(p => p.Brand)
                .Include(p => p.Promotion)
                .Include(p => p.Inventory.SellerInfo)
                .Include(p=>p.Category)
                .FirstOrDefault(p => p.ID == id);
            if (product == null)
            {
                return new HttpNotFoundResult("no product with that id");
            }
            product.Rate = calculateRate(product.ID);
            ProductViewModel productViewModel = new ProductViewModel();
            List<Product> products = db.Products
                .Where((p) => p.InventoryId == product.Inventory.ID && p.ID != product.ID)
                .ToList();
            bool isWished = false;
            bool isAddedToCart = false;
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                isWished = db.ProductWishlists.Any(p => p.ProductId == product.ID && p.wishListId == userId );
                isAddedToCart = IsAddedToCart(product.ID);
            }
            productViewModel.Product = product;
            productViewModel.Albums = product.Albums;
            productViewModel.BrandName = product.Brand.Name;
            productViewModel.SellerName = product.Inventory.SellerInfo.BusinessName;
            productViewModel.OtherProducts = products;
            List<FeedBack> feedBacks = new List<FeedBack>();
            foreach (var item in product.OrderDetails)
            {
                if(item.FeedBack != null)
                feedBacks.Add(item.FeedBack);
            }
            productViewModel.FeedBacks = feedBacks;
            productViewModel.isAddedToCart = isAddedToCart;
            productViewModel.isWished = isWished;
            return View("~/Views/Product/ProductDetails.cshtml", productViewModel);
        }
        [HttpPost,Route("products/{id}")]
        public ActionResult AddToCart(int id)
        {
            if ((!User.Identity.IsAuthenticated || !User.IsInRole("customer")))
            {
                if (Request.IsAjaxRequest())
                    return Content(Url.Action("Login", "Account"));
                else
                    return RedirectToAction("Login", "Account");
            }
            CartViewModel order;
            Product product = db.Products.FirstOrDefault(p => p.ID == id);
            product.OrderDetailsCost = product.Cost;
            if(Session["order"] != null)
            {
               order = Session["order"] as CartViewModel;
               order.ProductsWithQuantity.Add(new ProductWithQuantityViewModel() {Product = product, Quantity=1});
                if(order.Coupon !=null)
                product.OrderDetailsCost = (float)Math.Round(product.Cost * (1 - order.Coupon.Discount),2);
                order.TotalPrice += product.OrderDetailsCost;
                order.totalQuantity++;
            }
            else
            {
                order = new CartViewModel();
                order.totalQuantity = 1;
                order.TotalPrice = product.OrderDetailsCost;
                order.ProductsWithQuantity = new List<ProductWithQuantityViewModel>();
                order.ProductsWithQuantity.Add(new ProductWithQuantityViewModel() { Product = product, Quantity = 1 });
            }
            order.TotalPrice = (float)Math.Round(order.TotalPrice, 2);
            Session["order"] = order;
            if(Request.IsAjaxRequest())
            {
                return Content("");
            }
            return RedirectToAction("Index","Cart");
        }

       

        public ViewResult Search(string Searching)
        {
            string min = Request.QueryString["min"];
            string max = Request.QueryString["max"];
            string rate = Request.QueryString["rating-input"];
            var SearchProduct = db.Products.Where(p => p.Name.Contains(Searching)).ToList();
            foreach (var product in SearchProduct)
            {
                product.Rate = calculateRate(product.ID);
            }
           
           
            if(min != null && max != null )
            {
               float fMin = float.TryParse(min,out fMin)?fMin:0;
               float fMax = float.TryParse(max, out fMax) ? fMax : float.MaxValue;
               SearchProduct = SearchProduct.Where(p => p.Cost >=fMin && p.Cost <= fMax).ToList();
            }
           if( rate != null)
            {
                int iRate = int.TryParse(rate, out iRate)? iRate : 0 ;
                SearchProduct = SearchProduct.Where(p => p.Rate >=iRate).ToList();
            }
            List<SearchViewModel> products = new List<SearchViewModel>();
            foreach(var item in SearchProduct)
            {
                bool isAddedtoCart = IsAddedToCart(item.ID);
                products.Add(new SearchViewModel() { Product = item, IsAddedToCart = isAddedtoCart });
            }
           
            ViewBag.searching = Searching;
            return View("~/views/Product/Search.cshtml",products);
        }
        [HttpPost]
        [Route("product/{id}/wish")]
        public ActionResult wish(int id)
        {
            if ((!User.Identity.IsAuthenticated || !User.IsInRole("customer")))
            {
                if (Request.IsAjaxRequest())
                    return Content(Url.Action("Login", "Account"));
                else
                    return RedirectToAction("Login", "Account");
            }
            string userId = User.Identity.GetUserId();
            db.ProductWishlists.Add(new ProductWishlist() { wishListId = userId, ProductId = id });
            db.SaveChanges();
            if (Request.IsAjaxRequest())
                return Content("");
            else
                return RedirectToAction("SavedItems", "customer");
        }
        [HttpPost]
        [Route("product/{id}/unwish")]
        public ActionResult Unwish(int id)
        {
            if ((!User.Identity.IsAuthenticated || !User.IsInRole("customer")))
            {
                if (Request.IsAjaxRequest())
                    return Content(Url.Action("Login", "Account"));
                else
                    return RedirectToAction("Login", "Account");
            }
            string userId = User.Identity.GetUserId();
            ProductWishlist wish = db.ProductWishlists.FirstOrDefault(w => w.ProductId == id && w.wishListId == userId);
            db.ProductWishlists.Remove(wish);
            db.SaveChanges();
            if (Request.IsAjaxRequest())
                return Content("");
            else
                return RedirectToAction("SavedItems","customer");
        }
        private decimal calculateRate(int id)
        {
            var orderDetails = db.OrderDetails.Where(o => o.ProductID == id);
            var averageRating = orderDetails.Include(o => o.FeedBack).Where(o => o.FeedBack != null).ToList();
            Decimal average = 0;
            if (averageRating.Count > 0)
            {
                foreach (var details in averageRating)
                {
                    average += details.FeedBack.Rate;
                }
                average /= averageRating.Count;
                average = Math.Round(average, 2);
            }
            return average;
        }
        private bool IsAddedToCart(int productId)
        {
            if (Session["order"] != null)
            {
                CartViewModel cart = Session["order"] as CartViewModel;
                foreach (var item in cart.ProductsWithQuantity)
                {
                    if (item.Product.ID == productId)
                    {
                       return true;
                    }
                }
            }
            return false;
        }

        // get create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.BrandId = new SelectList(db.Brands, "ID", "Name");

            ViewBag.PromotionsID = new SelectList(db.Promotions, "ID", "ReasonforDiscounts");
            return View();
        }
        // post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase pImage)
        {
            var user = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {

                string des1 = product.Description.Split('>')[1];
                string des2 = des1.Split('<')[0];
                product.Description = des2;
                db.Products.Add(product);
                db.SaveChanges();
                string imgname = product.ID.ToString() + product.Name + "." + pImage.FileName.Split('.')[1];
                pImage.SaveAs(Server.MapPath("~/images/ProductImageUploaded/") + imgname);
                product.Image = imgname;

                product.InventoryId = user;
                

                db.SaveChanges();
                

                return RedirectToAction("Index", "Home");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.PromotionsID = new SelectList(db.Promotions, "ID", "ReasonforDiscounts", product.PromotionsID);
            return View(product);
        }
    }
}