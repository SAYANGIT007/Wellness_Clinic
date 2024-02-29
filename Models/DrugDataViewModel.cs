//DrugDataViewModel.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace ClinicAutimation.Models
{
    public class DrugDataViewModel
    {
        [DisplayName("Drug Name")]
        public int drugId { get; set; }
        public string drugName { get; set; }
        public DateTime? drugExpiry { get; set; }
        public string drugDescription { get; set; }
        public string drugDosage { get; set; }
        public decimal? drugPrice { get; set; }
    }
}