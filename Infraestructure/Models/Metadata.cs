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
        [MinLength(6)]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Descripción es un campo obligatorio")]
        [MinLength(15)]
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
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} no tiene formato valido")]
        public string Imagen { get; set; }

        [Display(Name = "Ubicación")]
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
        [DataType(DataType.Date, ErrorMessage = "{0} no tiene formato valido")]
        public System.DateTime FechaNacimiento { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La clave es un campo obligatorio")]
        [MinLength(6)]
        public string Clave { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El rol es un campo obligatorio")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El estado es un campo obligatorio")]
        public bool Estado { get; set; }

        public virtual ICollection<RESERVA> RESERVA { get; set; }
        [Display(Name = "Rol")]
        public virtual ROL ROL { get; set; }
    }

    internal partial class TipoPagoMetadata
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es un campo obligatorio")]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El estado es un campo obligatorio")]
        public bool Estado { get; set; }

        public virtual ICollection<RESERVA> RESERVA { get; set; }


    }

    internal partial class ReservaMetadata
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "El id del usuario es un campo obligatorio")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El departamento es un campo obligatorio")]
        [Display(Name = "Departamento")]
        public int IdDepartamento { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El día de reservación es un campo obligatorio")]
        [Display(Name = "Fecha de reserva")]
        [DataType(DataType.Date, ErrorMessage = "{0} no tiene formato valido")]
        public System.DateTime FechaReserva { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El día limite de la reservación es un campo obligatorio")]
        [Display(Name = "Fecha fin de reserva")]
        [DataType(DataType.Date, ErrorMessage = "{0} no tiene formato valido")]
        public System.DateTime FechaFinReserva { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La forma de pago es un campo obligatorio")]
        [Display(Name = "Forma de pago")]
        public int IdTipoPago { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El N° Tarjeta es un campo obligatorio")]
        [Display(Name = "N° Tarjeta")]
        [DataType(DataType.CreditCard, ErrorMessage = "{0} no tiene formato valido")]
        public string NumeroTarjeta { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La cantidad de personas es un campo obligatorio")]
        [Display(Name = "Cantidad de personas")]
        public int CantPersonas { get; set; }
        [Display(Name = "SubTotal")]
        public decimal SubTotal { get; set; }
        [Display(Name = "Impuesto")]
        public decimal Impuesto { get; set; }
        [Display(Name = "Total a pagar")]
        public decimal Total { get; set; }
        [Display(Name = "Estado de reserva")]
        public bool Estado { get; set; }

        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }
        public virtual TIPOPAGO TIPOPAGO { get; set; }
        public virtual USUARIO USUARIO { get; set; }

        public virtual ICollection<SERVICIOS> SERVICIOS { get; set; }
    }


}

