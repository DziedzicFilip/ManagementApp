//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagementApp.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Projekty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projekty()
        {
            this.BudzetProjektu = new HashSet<BudzetProjektu>();
            this.HistoriaDzialanProjektu = new HashSet<HistoriaDzialanProjektu>();
            this.NotatkiProjekty = new HashSet<NotatkiProjekty>();
            this.PlikiProjekty = new HashSet<PlikiProjekty>();
            this.PodsumowanieCzasu = new HashSet<PodsumowanieCzasu>();
            this.RejestrCzasuPracyProjekt = new HashSet<RejestrCzasuPracyProjekt>();
            this.RyzykaProjektu = new HashSet<RyzykaProjektu>();
            this.Zadania = new HashSet<Zadania>();
            this.Tagi = new HashSet<Tagi>();
        }
    
        public int projekt_id { get; set; }
        public string nazwa { get; set; }
        public string opis { get; set; }
        public Nullable<System.DateTime> data_rozpoczecia { get; set; }
        public Nullable<System.DateTime> data_zakonczenia { get; set; }
        public string status { get; set; }
        public string priorytet { get; set; }
        public Nullable<System.DateTime> termin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BudzetProjektu> BudzetProjektu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoriaDzialanProjektu> HistoriaDzialanProjektu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NotatkiProjekty> NotatkiProjekty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlikiProjekty> PlikiProjekty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PodsumowanieCzasu> PodsumowanieCzasu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RejestrCzasuPracyProjekt> RejestrCzasuPracyProjekt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RyzykaProjektu> RyzykaProjektu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zadania> Zadania { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tagi> Tagi { get; set; }
    }
}
