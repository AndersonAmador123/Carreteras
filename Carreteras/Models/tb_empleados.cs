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
    
    public partial class tb_empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_empleados()
        {
            this.tb_empleadosXusuarios = new HashSet<tb_empleadosXusuarios>();
        }
    
        public string emp_id { get; set; }
        public string emp_nombre { get; set; }
        public Nullable<int> emp_edad { get; set; }
        public string emp_telefono { get; set; }
        public string ciu_id { get; set; }
        public string emp_usuario_crea { get; set; }
        public Nullable<System.DateTime> emp_fecha_crea { get; set; }
        public string emp_usuario_modifica { get; set; }
        public Nullable<System.DateTime> emp_fecha_modifica { get; set; }
        public Nullable<bool> emp_estado { get; set; }
    
        public virtual tb_ciudades tb_ciudades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_empleadosXusuarios> tb_empleadosXusuarios { get; set; }
        public virtual tb_usuarios tb_usuarios { get; set; }
        public virtual tb_usuarios tb_usuarios1 { get; set; }
    }
}
