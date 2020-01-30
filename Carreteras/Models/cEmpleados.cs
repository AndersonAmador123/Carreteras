using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carreteras.Models
{
    [MetadataType(typeof(cEmpleadosMetadata))]
    public partial  class tb_empleados
    {
    }
    public class cEmpleadosMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Codigo")]
        public string emp_id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Nombre")]
        public string emp_nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Edad")]
        public Nullable<int> emp_edad { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Telefono")]
        public string emp_telefono { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Codigo Ciudad")]
        public string ciu_id { get; set; } 
        [Display(Name = "Usuario Crea")]
        public string emp_usuario_crea { get; set; }
        [Display(Name = "Fecha Crea")]
        public Nullable<System.DateTime> emp_fecha_crea { get; set; }
        [Display(Name = "Usuario Modifica")]
        public string emp_usuario_modifica { get; set; }
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> emp_fecha_modifica { get; set; }
        [Display(Name = "Estado")]
        public Nullable<bool> emp_estado { get; set; }


    }
}