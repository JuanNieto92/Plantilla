//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Plantilla.Models.BD_REVISTAS
{
    using System;
    using System.Collections.Generic;
    
    public partial class USR_PaginaSitioWeb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USR_PaginaSitioWeb()
        {
            this.USR_PermisoSitioWeb = new HashSet<USR_PermisoSitioWeb>();
        }
    
        public int Id { get; set; }
        public string App { get; set; }
        public string Controlador { get; set; }
        public string Funcion { get; set; }
        public string Icono { get; set; }
        public string Nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USR_PermisoSitioWeb> USR_PermisoSitioWeb { get; set; }
    }
}
