using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace CinicAutomation.Models
{
    public class LoginModel
    {
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Enter valid Username")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Enter valid Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Nullable<int> patientFk { get; set; }
        public Nullable<int> physicianFk { get; set; }
        public Nullable<int> chemistFk { get; set; }
        public Nullable<int> adminFk { get; set; }
        public Nullable<int> supplierFk { get; set; }
        public Nullable<int> roleFk { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Chemist Chemist { get; set; }
        public virtual patient patient { get; set; }
        public virtual physician physician { get; set; }
        public virtual role role { get; set; }
        public virtual supplier supplier { get; set; }
    }
}