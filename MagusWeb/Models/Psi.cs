//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagusWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Psi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Psi()
        {
            this.Character = new HashSet<Character>();
            this.MagusClass = new HashSet<MagusClass>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public Nullable<short> Base { get; set; }
        public Nullable<short> Further { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Character> Character { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MagusClass> MagusClass { get; set; }
    }
}