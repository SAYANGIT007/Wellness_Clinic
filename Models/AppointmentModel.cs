using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CinicAutomation.Models
{
    
    public class AppointmentModel
    {
        public int AppointmentModelID { get; set; }
        public int patientFk { get; set; }
        [Display(Name = "Physician")]
        public int physicianFk { get; set; }

        [Required(ErrorMessage = "Date Cannot be blank")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime AppDate { get; set; }

        [Display(Name = "Criticality")]
        public string AppCriticality { get; set; }

        [Display(Name = "Reason")]
        public string AppReason { get; set; }

        [Display(Name = "Status")]
        public string AppStatus { get; set; }
        public Nullable<int> scheduleFk { get; set; }
        public Nullable<int> prescriptionFk { get; set; }

        public virtual prescription prescription { get; set; }
        public virtual schedule schedule { get; set; }
        public virtual patient patient { get; set; }
        public virtual physician physician { get; set; }
    }
}