using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinicAutomation.Models
{
    public class patientModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public System.DateTime dob { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string history { get; set; }
        public string address { get; set; }
        public string phone { get; set; }


    }
}