using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicationCore.Services;
using Infraestructure.Models;

namespace Web.Views.ViewModel
{
    public class viewModelReservaDetalle
    {
        public int IdReserva { get; set; }
        public int IdDepartamento { get; set; }
        public string Imagen { get; set; }
        public int IdServicio { get; set; }
        public SERVICIOS Servicios{get; set;}
        public int Cantidad { get; set; }
        public decimal Precio
        {
            get { return Departamento.Tarifa; }

        }

        public decimal PrecioServicios
        {
            get
            {
                return calculoServicios();
            }
        }

        public virtual DEPARTAMENTO Departamento { get; set; }
        public IEnumerable<SERVICIOS> lista { get; set; }

        public void asignarServicios(int[] selectedServicios)
        {
            ServiceServicio _ServiceServicio = new ServiceServicio();
            this.lista = _ServiceServicio.listaServiciosEscogidos(selectedServicios);

        }
        
        public decimal SubTotal
        {
            get
            {
                return calculoSubtotal();
            }
        }

        public decimal Impuesto
        {
            get
            {
                return calculoImpuesto();
            }
        }

        public decimal Total
        {
            get
            {
                return calculoSubtotal() + Impuesto;
            }
        }
        private decimal calculoSubtotal()
        {
            return this.Precio + calculoServicios();
        }

        private decimal calculoServicios()
        {
            decimal total = 0;
            if (lista != null)
            {
                foreach (var item in lista)
                {
                    total += item.Precio;
                }
            }
            return total;
        }

        public decimal calculoImpuesto()
        {
            return this.Precio * ((decimal)0.13);
        }

        public viewModelReservaDetalle(int IdDepartamento)
        {
            ServiceDepartamento _ServiceDepartamento = new ServiceDepartamento();
            this.IdDepartamento = IdDepartamento;
            this.Departamento = _ServiceDepartamento.GetDepartamentoActivoByID(IdDepartamento);
            
        }


    }
}