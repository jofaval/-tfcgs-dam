//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiagramEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class PermisosUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermisosUsuario()
        {
            this.Usuario = new HashSet<Usuario>();
        }
    
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool PermisoAdministrativo { get; set; }
        public bool PermisoAdmin { get; set; }
        public bool PermisProfesor { get; set; }
        public bool PermisoAlumno { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
