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
    
    public partial class Subscriptions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscriptions()
        {
            this.SaleSubscription = new HashSet<SaleSubscription>();
        }
    
        public int IdSubscription { get; set; }
        public string NameSubscription { get; set; }
        public decimal Price { get; set; }
        public string NumberOfDays { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleSubscription> SaleSubscription { get; set; }
    }
}
