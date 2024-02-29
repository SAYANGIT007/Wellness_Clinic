using ClinicAutimation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Web;
using System.Web.Mvc;

namespace ClinicAutimation.Models
{
    public class PurchaseOrderViewModel
    {
        public int PurchaseOrderID { get; set; }
        public int PurchaseQuantity { get; set; }
        public string PurchaseCompany { get; set; }
        public int PurchaseDrugID { get; set; }
        public int PurchaseSupplierID { get; set; }
        public string PurchaseOrderName { get; set; }
        public string PurchaseOrderStatus { get; set; }
        public virtual Drug Drug { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}