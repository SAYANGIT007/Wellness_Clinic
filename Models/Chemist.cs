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
    
    public partial class Chemist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chemist()
        {
            this.tbl_login = new HashSet<tbl_login>();
        }
    
        public int ChemistId { get; set; }
        public string ChemistName { get; set; }
        public string ChemistPh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_login> tbl_login { get; set; }
    }
}
