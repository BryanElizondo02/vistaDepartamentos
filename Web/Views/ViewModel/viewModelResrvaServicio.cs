using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicationCore.Services;
using Infraestructure.Models;

namespace Web.Views.ViewModel
{
    public class viewModelReservaServicio
    {
        public int IdReserva { get; set; }
        
        public int IdServicio { get; set; }
        public SERVICIOS Servicios { get; set; }
        public decimal Precio
        { set; get; }

        public virtual DEPARTAMENTO Departamento { get; set; }

        public decimal Total
        {
            get
            {
                return Precio;
            }
        }

        public string Nombre
        {
            get
            {
                return Servicios.Nombre;
            }
        }

        public string Descripcion
        {
            get
            {
                return Servicios.Descripcion;
            }
        }

        public viewModelReservaServicio(int Idservicio)
        {
            ServiceServicio _serviceServicio = new ServiceServicio();
            this.IdServicio = Idservicio;
            Servicios = _serviceServicio.GetServicioByID(Idservicio);
            

        }
        

    }
}