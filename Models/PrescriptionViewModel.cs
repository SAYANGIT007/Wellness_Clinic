using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicAutimation.Models
{
    public class PrescriptionViewModel
    {
        public Appointment Appointment { get; set; }
        public Patient Patient { get; set; }
        public PhysicianPrescription Prescription { get; set; }
        public string PrescriptionDescription { get; set; }
    }
}