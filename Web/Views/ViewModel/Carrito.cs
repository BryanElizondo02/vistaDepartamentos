using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Util;

namespace Web.Views.ViewModel
{
    public class Carrito
    {
        int departamento;
        public List<viewModelReservaDetalle> Items { get; private set; }


        public static readonly Carrito Instancia;

        static Carrito()
        {
            if (HttpContext.Current.Session["carrito"] == null)
            {
                Instancia = new Carrito();
                Instancia.Items = new List<viewModelReservaDetalle>();
                //Instancia.ItemsServicio = new List<viewModelReservaServicio>();
                HttpContext.Current.Session["carrito"] = Instancia;
            }
            else
            {
                Instancia = (Carrito)HttpContext.Current.Session["carrito"];
            }
        }

        protected Carrito() { }

        public String AgregarItem(int departamentoId)
        {
            departamento = departamentoId;
            String mensaje = "";
            // Crear un nuevo artículo para agregar al carrito
            viewModelReservaDetalle nuevoItem = new viewModelReservaDetalle(departamentoId);

            if (nuevoItem != null)
            {
                if (Items.Exists(x => x.IdDepartamento == departamentoId))
                {
                    mensaje = SweetAlertHelper.Mensaje("Reservación", "Ya agrego este departamento a su lista de deseos", SweetAlertMessageType.error);

                }
                else
                {
                    Items.Add(nuevoItem);
                }
                mensaje = SweetAlertHelper.Mensaje("Reservación", "Departamento agregado a la lista de deseos", SweetAlertMessageType.success);

            }
            else
            {
                mensaje = SweetAlertHelper.Mensaje("Reservación", "El departamento solicitado no existe", SweetAlertMessageType.warning);
            }
            return mensaje;
        }



        public String EliminarItem(int departamentoId)
        {
            

            String mensaje = "El departamento solicitado no existe";
            if (Items.Exists(x => x.IdDepartamento == departamentoId))
            {
                var itemEliminar = Items.Single(x => x.IdDepartamento == departamentoId);
                Items.Remove(itemEliminar);
                mensaje = SweetAlertHelper.Mensaje("Reservación", "Eliminado de la lista de deseos", SweetAlertMessageType.success);
            }
            return mensaje;

        }

        

        public decimal GetSubTotal()
        {
            decimal total = 0;
            total = Items.Sum(x => x.SubTotal);

            return total;
        }

        public decimal GetTotal()
        {
            decimal total = 0;
            total = Items.Sum(x => x.Total);

            return total;
        }

        public int GetCountItems()
        {
            int total = 0;
            total = Items.Sum(x => x.Cantidad);

            return total;
        }

        public void eliminarCarrito()
        {
            Items.Clear();

        }


    }
}