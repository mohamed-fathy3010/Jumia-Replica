﻿using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace GraduationProject.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Account()
        {
            return View("~/Views/Account/Customer/Account.cshtml");
        }
        [Route("customer/account/edit")]
        public ActionResult AccountEdit()
        {
            return View("~/Views/Account/Customer/AccountEdit.cshtml");
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
        public ActionResult OrderHistory()
        {
            string ID = User.Identity.GetUserId();

            var user = db.Users.FirstOrDefault(l=>l.Id== ID);

            var order = db.Customers.Where(c => c.Orders.Any(o => o.OrderDetails.Any(k => k.Status == OrderDetailsStatus.completed))).ToList().SingleOrDefault(h => h.ID == ID);
            //var otherorder = db.Customers.Where(q => q.ID == ID)
            //                                   .Include(q => q.Orders).Include(p=>p.ord).Select(t => t.OrderDetails))
            //                                   .ToList();

            var otherorder = db.Orders.Include(o => o.OrderDetails).Where(l => l.CustomerID == ID);
            //var OrderDetails = otherorder.Where(u=>u.OrderDetails.Where(t=>t.Status==OrderDetailsStatus.completed))

            //var orders = from o in db.Orders
            //             select new
            //             {
            //                 order = (from _order in o.OrderDetails
            //                          select new
            //                          {
            //                              m = (from _orderdetails in _order.Status
            //                                   select new
            //                                   {
            //                                       n = (from _orderstatus in _orderdetails.status
            //                                            where _orderstatus == "completed" select OrderDetailsStatus.completed)
            //                               })
            //                          })
            //             }

            //var orders = (from e in db.orders
            //              where e.id == id
            //              select e)
            //          .include(x => x.orders)
            //          .include(x => x.orders.select(r => r.orderdetails)).s
            //          .include(x => x.ordersde.select(r => r.ord).select(rt => rt.ruletype))
            //          .include(x => x.shifts.select(r => r.rate).select(rt => rt.ratetype))
            //          .firstordefaultasync();

            //var o= db.Orders.Include(l=>l.OrderDetails.Select(b=>b.Status).Where(OrderDetailsStatus.completed,))

            // not working code

            // var orders = db.Customers.Include(d => d.Orders).Select(m => m.Orders.OrderDetails.Where(n => n.Status == OrderDetailsStatus.completed)).ToList();

            // var order= db.OrderDetails.Where(m => m.Status == OrderDetailsStatus.completed).ToList();

            return View(order);
        }
    }
}