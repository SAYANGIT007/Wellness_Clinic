//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinicAutomation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class appointment
    {
        public int AppointID { get; set; }
        public int patientFk { get; set; }
        public int physicianFk { get; set; }
        public System.DateTime AppDate { get; set; }
        public string AppCriticality { get; set; }
        public string AppReason { get; set; }
        public string AppStatus { get; set; }
        public Nullable<int> scheduleFk { get; set; }
        public Nullable<int> prescriptionFk { get; set; }
    
        public virtual patient patient { get; set; }
        public virtual physician physician { get; set; }
        public virtual prescription prescription { get; set; }
        public virtual schedule schedule { get; set; }
    }
}