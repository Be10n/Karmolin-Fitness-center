//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Karmolin_Fitness_Center_.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SaleSubscription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaleSubscription()
        {
            this.AttendanceRecords = new HashSet<AttendanceRecords>();
        }
    
        public int IdCard { get; set; }
        public int IdUser { get; set; }
        public int IdSubscription { get; set; }
        public System.DateTime StartDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendanceRecords> AttendanceRecords { get; set; }
        public virtual Subscriptions Subscriptions { get; set; }
        public virtual User User { get; set; }
    }
}
