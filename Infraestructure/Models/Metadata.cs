using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
    internal partial class DepartamentoMetadata
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Display(Name = "Ubicación")]
        public int IdUbicacion { get; set; }
        [Display(Name = "Tarifa Mensual")]
        public decimal Tarifa { get; set; }
        [Display(Name = "Disponibilidad")]
        public bool Estado { get; set; }
        public string Imagen { get; set; }

        [Display(Name = "Ubicacion")]
        public virtual UBICACION UBICACION { get; set; }
        [Display(Name = "Reserva")]
        public virtual ICollection<RESERVA> RESERVA { get; set; }
        [Display(Name = "Extras")]
        public virtual ICollection<EXTRA> EXTRA { get; set; }

    }

    internal partial class ExtraMetadata
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        [Display(Name = "Detalle")]
        public virtual ICollection<DEPARTAMENTO> DEPARTAMENTO { get; set; }

    }

    internal partial class UsuarioMetadata
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre es un campo obligatorio")]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Primer apellido es un campo obligatorio")]
        [Display(Name = "Primer Apellido")]
        public string Apellido1 { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Segundo apellido es un campo obligatorio")]
        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El correo es un campo obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage ="{0} no tiene formato valido")]
        public string Correo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El telefono es un campo obligatorio")]
        public string Telefono { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El sexo es un campo obligatorio")]
        public string Sexo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La fecha de nacimiento es un campo obligatorio")]
        [Display(Name = "Fecha de Nacimiento")]
        public System.DateTime FechaNacimiento { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La clave es un campo obligatorio")]
        [MinLength(6)]
        public string Clave { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El rol es un campo obligatorio")]
        public int IdRol { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El estado es un campo obligatorio")]
        public bool Estado { get; set; }

        public virtual ICollection<RESERVA> RESERVA { get; set; }
        [Display(Name = "Rol")]
        public virtual ROL ROL { get; set; }
    }


}

