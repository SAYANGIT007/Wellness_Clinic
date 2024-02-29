using CinicAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ClinicAutimation.Controllers
{
    public class SupplierController : Controller
    {
        Models.MyclinicEntities _db = new Models.MyclinicEntities();
        // GET: supplier
        public ActionResult Login()
        { // Supplier logins
            return View();
        }
        [HttpPost]
        public ActionResult Login(SupplierLoginModel model)
        { // Patient logins
            using (var context = new MyclinicEntities())
            {
                SupplierLogin obj = context.SupplierLogins.Where(x => x.Username == model.Username && x.Password == model.Password).SingleOrDefault();
                if (obj != null)
                {
                    Session["ID"] = obj.SupplierID;
                    return RedirectToAction("GetDetailPurchaseOrder");
                }
            }

            return View();
        }

        public ActionResult GetDetailPurchaseOrder()
        {
            // Appointment details get displayed 
            int ID = Convert.ToInt32(Session["ID"]);
            using (var context = new MyclinicEntities())
            {
                var defaultOptions = new SelectList(new[]
        {
            new SelectListItem { Text = "Pending", Value = "Pending" },
            new SelectListItem { Text = "Approved", Value = "Approved" },
            new SelectListItem { Text = "Rejected", Value = "Rejected" }
        }, "Value", "Text");

                // Pass the purchase orders and dropdown list options to the view
                ViewBag.DefaultOptions = defaultOptions;

                var result = context.PurchaseOrders.Include("Drug").Include("Supplier").ToList().Where(x => x.PurchaseSupplierID == ID).Select(x => new PurchaseOrderViewModel()
                {

                    Drug = new Drug()
                    {
                        drugName = x.Drug.drugName
                    },
                    Supplier = new Supplier()
                    {
                        SupplierName = x.Supplier.SupplierName
                    },
                    PurchaseDrugID = x.PurchaseDrugID,
                    PurchaseOrderName = x.PurchaseOrderName,
                    PurchaseCompany = x.PurchaseCompany,
                    PurchaseQuantity = x.PurchaseQuantity,
                    PurchaseOrderID = x.PurchaseOrderID,
                    PurchaseSupplierID = x.PurchaseSupplierID,
                    PurchaseOrderStatus = x.PurchaseOrderStatus,



                }).ToList();

                return View(result);
            }

        }
        [HttpPost]
        public ActionResult GetDetailPurchaseOrder(int? id, string SelectedStatus)
        {
            var purchaseOrder = _db.PurchaseOrders.Find(id);
            purchaseOrder.PurchaseOrderStatus = SelectedStatus;

            _db.SaveChanges();

            return RedirectToAction("GetDetailPurchaseOrder");

        }
    }
}