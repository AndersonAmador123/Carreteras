using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Carreteras.Models
{
    [MetadataType(typeof(cCategoriasMetadata))]
    public partial class tb_categorias
    {
    }
    public class cCategoriasMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Codigo")]
        public string cat_id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Descripcion")]
        public string cat_descripcion { get; set; }
        [Display(Name = "Usuario Crea")]
        public string cat_usuario_crea { get; set; }
        [Display(Name = "Fecha Crea")]
        public Nullable<System.DateTime> cat_fecha_crea { get; set; }
        [Display(Name = "Usuario Modifica")]
        public string cat_usuario_modifica { get; set; }
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> cat_fecha_modifica { get; set; }
        [Display(Name = "Estado")]
        public Nullable<bool> cat_estado { get; set; }



    }
}