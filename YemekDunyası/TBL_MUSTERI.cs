//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YemekDunyası
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_MUSTERI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MUSTERI()
        {
            this.TBL_SIPARIS = new HashSet<TBL_SIPARIS>();
        }
    
        public int KullaniciID { get; set; }
        public string KullaniciSifre { get; set; }
        public string KullaniciAD { get; set; }
        public string KullaniciSOYAD { get; set; }
        public string KullaniciNick { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SIPARIS> TBL_SIPARIS { get; set; }
    }
}
