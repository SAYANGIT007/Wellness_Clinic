using ClinicAutimation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicAutimation.Models
{
    public class SupplierLoginModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}