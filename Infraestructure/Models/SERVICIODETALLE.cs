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
    
    public partial class SERVICIODETALLE
    {
        public int IdServicio { get; set; }
        public int Secuencia { get; set; }
        public int IdReserva { get; set; }
    
        public virtual RESERVA RESERVA { get; set; }
        public virtual SERVICIOS SERVICIOS { get; set; }
    }
}
