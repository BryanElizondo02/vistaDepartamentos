//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructure.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class EXTRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EXTRA()
        {
            this.DEPARTAMENTO = new HashSet<DEPARTAMENTO>();
        }
    
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Descripción es un campo obligatorio")]
        [StringLength(10), MinLength(3)]
        public string Descripcion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Estado es un campo obligatorio")]
        public bool Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTAMENTO> DEPARTAMENTO { get; set; }
    }
}
