//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Carreteras.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_departamentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_departamentos()
        {
            this.tb_ciudades = new HashSet<tb_ciudades>();
        }
    
        public string dep_id { get; set; }
        public string dep_descripcion { get; set; }
        public string dep_usuario_crea { get; set; }
        public Nullable<System.DateTime> dep_fecha_crea { get; set; }
        public string dep_usuario_modifica { get; set; }
        public Nullable<System.DateTime> dep_fecha_modifica { get; set; }
        public Nullable<bool> dep_estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ciudades> tb_ciudades { get; set; }
        public virtual tb_usuarios tb_usuarios { get; set; }
        public virtual tb_usuarios tb_usuarios1 { get; set; }
    }
}