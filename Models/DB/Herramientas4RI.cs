//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoAula4MVC.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Herramientas4RI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Herramientas4RI()
        {
            this.Ideas_De_Negocio = new HashSet<Ideas_De_Negocio>();
        }
    
        public int ID_Herramienta { get; set; }
        public string Nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ideas_De_Negocio> Ideas_De_Negocio { get; set; }
    }
}