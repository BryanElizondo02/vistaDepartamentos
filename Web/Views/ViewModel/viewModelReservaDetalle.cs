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

        public virtual DEPARTAMENTO Departamento { get; set; }

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
                return calculoSubtotal() + calculoImpuesto();
            }
        }
        private decimal calculoSubtotal()
        {
            return this.Precio;
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