using CinicAutomation.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ClinicAutimation.Controllers
{
    public class ChemistController : Controller
    {

        Models.MyclinicEntities _db = new MyclinicEntities();


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
                    return RedirectToAction("ChemistLandingPage");
                }
            }

            return View();
        }
        // GET: Chemist
        public ActionResult ChemistLandingPage()
        {
            return View();
        }
        public ActionResult SetPurchaseOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetPurchaseOrder(PurchaseOrderViewModel model)
        {
            using (var context = new MyclinicEntities())
            {
                PurchaseOrder obj = new PurchaseOrder()
                {
                    PurchaseOrderName = model.PurchaseOrderName,
                    PurchaseQuantity = model.PurchaseQuantity,
                    PurchaseCompany = model.PurchaseCompany,
                    PurchaseDrugID = model.PurchaseDrugID,
                    PurchaseSupplierID = model.PurchaseSupplierID,
                    PurchaseOrderStatus = model.PurchaseOrderStatus,

                };
                context.PurchaseOrders.Add(obj);
                context.SaveChanges();

            }
            return RedirectToAction("ChemistLandingPage");
        }
        public ActionResult SetDrugData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetDrugData(DrugDataViewModel model)
        {
            using (var context = new MyclinicEntities())
            {
                Drug obj1 = new Drug()
                {
                    drugName = model.drugName,
                    drugExpiry = model.drugExpiry,
                    drugDescription = model.drugDescription,
                    drugDosage = model.drugDosage,
                    drugPrice = model.drugPrice,
                };
                context.Drugs.Add(obj1);
                context.SaveChanges();

            }
            return View();
        }

        public ActionResult GetDrugList()
        {
            List<Drug> druglist = new List<Drug>();
            using (MyclinicEntities db = new MyclinicEntities())
            {
                druglist = db.Drugs.ToList<Drug>();
            }
            return View(druglist);
        }

        [HttpPost]
        public List<DrugDataViewModel> DrugList()
        {
            using (var context = new MyclinicEntities())
            {
                var result = context.Drugs
                    .Select(x => new DrugDataViewModel()
                    {
                        drugId = x.drugID,
                        drugDescription = x.drugDescription,
                        drugName = x.drugName,
                        drugDosage = x.drugDosage,
                        drugExpiry = x.drugExpiry,
                        drugPrice = x.drugPrice
                    }).ToList();

                return result;
            }

        }

        public ActionResult EditDrugData(int id)
        {
            return View(_db.Drugs.Find(id));
        }

        [HttpPost]
        public ActionResult EditDrugData(int drugID, DrugDataViewModel model)
        {
            using (var context = new MyclinicEntities())
            {
                var drug = context.Drugs.FirstOrDefault(x => x.drugID == drugID);

                if (drug != null)
                {
                    drug.drugName = model.drugName;
                    drug.drugExpiry = model.drugExpiry;
                    drug.drugPrice = model.drugPrice;
                    drug.drugDosage = model.drugDosage;
                    drug.drugDescription = model.drugDescription;
                }
                context.SaveChanges();

            }
            return RedirectToAction("ChemistLandingPage");

        }


        public ActionResult DeleteDrug(int id)
        {
            Drug DrugModel = new Drug();

            using (MyclinicEntities db = new MyclinicEntities())
            {
                DrugModel = db.Drugs.Where(x => x.drugID == id).FirstOrDefault();
            }
            return View(DrugModel);
        }
        [HttpPost]
        public ActionResult DeleteDrug(int id, FormCollection collection)
        {
            using (MyclinicEntities db = new MyclinicEntities())
            {
                Drug DrugModel = db.Drugs.Where(x => x.drugID == id).FirstOrDefault();
                db.Drugs.Remove(DrugModel);
                db.SaveChanges();
            }
            return RedirectToAction("ChemistLandingPage");

        }
    }
}
