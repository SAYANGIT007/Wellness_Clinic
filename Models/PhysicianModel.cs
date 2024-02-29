using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinicAutomation.Models
{
    public class PhysicianModel
    {
        public int physicianID { get; set; }
        [Required]
        public string physicianName { get; set; }
        [Required]
        public string physicianGender { get; set; }
        [Required]
        public string physicianEmail { get; set; }
        [Required]
        public string physicianSpecialization { get; set; }
        public string physicianAddress { get; set; }
        public string physicianContact { get; set; }
    }
}