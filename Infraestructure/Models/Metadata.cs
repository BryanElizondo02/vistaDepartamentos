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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre es un campo obligatorio")]
        [StringLength(10), MinLength(6)]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Descripción es un campo obligatorio")]
        [StringLength(30), MinLength(15)]
        public string Descripcion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La ubicación es un campo obligatorio")]
        [Display(Name = "Ubicación")]
        public int IdUbicacion { get; set; }
        [Display(Name = "Tarifa Mensual")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La Tarifa a cobrar es un campo obligatorio")]
        public decimal Tarifa { get; set; }
        [Display(Name = "Disponibilidad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La disponibilidad es una opción requerida")]
        public bool Estado { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La URL de la imagen es requerida")]
        public string Imagen { get; set; }

        [Display(Name = "Ubición")]
        public virtual UBICACION UBICACION { get; set; }
        [Display(Name = "Reserva")]
        public virtual ICollection<RESERVA> RESERVA { get; set; }
        [Display(Name = "Extras")]
        public virtual ICollection<EXTRA> EXTRA { get; set; }

    }

    internal partial class ExtraMetadata
    {

        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Descripción es un campo obligatorio")]
        [StringLength(20), MinLength(3)]
        public string Descripcion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Estado es un campo obligatorio")]
        public bool Estado { get; set; }

        [Display(Name = "Detalle")]
        public virtual ICollection<DEPARTAMENTO> DEPARTAMENTO { get; set; }

    }

    internal partial class RolMetadata
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Descripción es un campo obligatorio")]
        public string Descripcion { get; set; }

        public virtual ICollection<USUARIO> USUARIO { get; set; }
    }

    internal partial class UbicacionMetadata
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre es un campo obligatorio")]
        [StringLength(30), MinLength(5)]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Estado es un campo obligatorio")]
        public bool Estado { get; set; }

        public virtual ICollection<DEPARTAMENTO> DEPARTAMENTO { get; set; }
    }

    internal partial class ServiciosMetadata
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre es un campo obligatorio")]
        [MinLength(6)]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Descripción es un campo obligatorio")]
        [MinLength(6)]
        public string Descripcion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Precio es un campo obligatorio")]
        public decimal Precio { get; set; }
        [Display(Name = "Disponibilidad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La disponibilidad es una opción requerida")]
        public Nullable<bool> Estado { get; set; }

        public virtual ICollection<RESERVA> RESERVA { get; set; }
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

