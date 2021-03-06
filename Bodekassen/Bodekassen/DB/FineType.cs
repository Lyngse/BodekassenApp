//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bodekassen.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class FineType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FineType()
        {
            this.Fines = new HashSet<Fine>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> DefaultPrice { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCaseOfBeer { get; set; }
        public bool IsDeposit { get; set; }
        public int TeamId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fine> Fines { get; set; }
        public virtual Team Team { get; set; }
    }
}
