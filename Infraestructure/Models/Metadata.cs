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

}
