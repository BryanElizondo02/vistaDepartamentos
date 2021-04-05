using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.Services;
using Infraestructure.Models;
using Web.Enum;
using Web.Views.ViewModel;

namespace Web.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Reservas()
        {
            IEnumerable<RESERVA> lista = null;
            try
            {
                USUARIO oUser = (Infraestructure.Models.USUARIO)Session["User"];
                ServiceReserva _serviceReserva = new ServiceReserva();
                lista = _serviceReserva.GetReserva(oUser.Id);
                ViewBag.DetalleReserva = Carrito.Instancia.Items;
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData.Keep();
            }
            return View(lista);
        }

        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult ReservasAdmin()
        {
            IEnumerable<RESERVA> lista = null;
            try
            {
                ServiceReserva _serviceReserva = new ServiceReserva();
                lista = _serviceReserva.GetReservaAdmin();

            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData.Keep();
            }
            return View(lista);
        }

        public ActionResult Details(int? id)
        {
            ServiceReserva _serviceReserva = new ServiceReserva();
            RESERVA oReserva = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("ReservasAdmin");
                }

                oReserva = _serviceReserva.GetReservaByID(id.Value);
                if (oReserva == null)
                {

                    //return RedirectToAction("Ubicaciones");
                    TempData["Message"] = "No existen los registros solicitados";
                    TempData["Redirect"] = "Reserva";
                    TempData["Redirect-Action"] = "ReservasAdmin";

                    return RedirectToAction("Default", "Error");
                }
                return View(oReserva);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "No existen los registros solicitados";
                TempData["Redirect"] = "Reserva";
                TempData["Redirect-Action"] = "ReservasAdmin";

                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Create()
        {
            ViewBag.TipoPago = this.listTipoPago();
            ViewBag.DetalleReserva = Carrito.Instancia.Items;
            ViewBag.IdServicios = listServicio();
            return View();
        }

        private SelectList listServicio(int idServicio = 0)
        {
    
            ServiceServicio _serviceServicio = new ServiceServicio();
            IEnumerable<SERVICIOS> listaServicio= _serviceServicio.GetServicioActivo();
       
            if (idServicio != 0)
            {
                ViewBag.contratarServ = idServicio;
            }
            else
            {
                ViewBag.contratarServ = 0;
            }

            return new SelectList(listaServicio, "Id", "Nombre", idServicio);//List to Dropdown List
            
        }

        public ActionResult ordenarDepartamento(int? idDepartamento)
        {
            if (ViewBag.NotiCarrito = Carrito.Instancia.Items.Count == 0)
            {
                ViewBag.NotiCarrito = Carrito.Instancia.AgregarItem((int)idDepartamento);
            }
             
            return RedirectToAction("Create");

        }

        public ActionResult ordenarServicios(int id = 0)
        {
            if (ViewBag.NotiCarrito = Carrito.Instancia.Items.Count > 0)
            {
                ViewBag.IdServicioContratar = id;
                Carrito.Instancia.AgregarItemServicio((int)id);
            }
            
            return RedirectToAction("Create");

        }

        private SelectList listTipoPago(int idTipoPago = 0)
        {
            ServiceTipoPago _serviceTipoPago = new ServiceTipoPago();
            IEnumerable<TIPOPAGO> listaTipoPago = _serviceTipoPago.GetTipoPagoActivo();
            

            return new SelectList(listaTipoPago, "Id", "Nombre", idTipoPago);//List to Dropdown List
        }

        private MultiSelectList listaServicios(ICollection<SERVICIOS> servicios)
        {
            ServiceServicio _serviceServicios = new ServiceServicio();
            IEnumerable<SERVICIOS> listaServicio = _serviceServicios.GetServicioActivo();
            int[] listaServicioSelect = null;

            if (servicios != null)
            {
                listaServicioSelect = servicios.Select(e => e.Id).ToArray();
                ViewBag.listaseleccionados = listaServicioSelect;
                
            }

            return new MultiSelectList(listaServicio, "Id", "Nombre", listaServicioSelect);
        }

        

        [HttpPost]
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Edit(int id)
        {
            ServiceReserva _serviceReserva = new ServiceReserva();
            RESERVA oReserva = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Servicios");
                }

                oReserva = _serviceReserva.GetReservaByID(id);
                if (oReserva == null)
                {
                    TempData["Message"] = "No existe la reserva solicitada";
                    TempData["Redirect"] = "Reserva";
                    TempData["Redirect-Action"] = "ReservasAdmin";

                    return RedirectToAction("Default", "Error");
                }
                ViewBag.IdServicios = listaServicios(oReserva.SERVICIOS);

                return View(oReserva);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Reserva";
                TempData["Redirect-Action"] = "ReservasAdmin";

                return RedirectToAction("Default", "Error");
            }
        }


        public ActionResult Save(RESERVA reserv, string[] selectedServicios)
        {
            ServiceReserva _serviceReserva = new ServiceReserva();
            USUARIO oUser = null;
            

            try
            {
                    oUser = (Infraestructure.Models.USUARIO)Session["User"];
                    reserv.Estado = true;
                    reserv.IdUsuario = oUser.Id;

                    if (ModelState.IsValid)
                    {
                        RESERVA oReserva = _serviceReserva.Save(reserv, selectedServicios);

                    }
                    else
                    {
                        Util.Util.ValidateErrors(this);
                        ViewBag.IdServicios = listaServicios(reserv.SERVICIOS);
                        return View("Create", reserv);
                    }

                    return RedirectToAction("Reservas");
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Reserva";
                TempData["Redirect-Action"] = "Reservas";

                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult eliminarListaDepartamento(int? idDepartamento)
        {
            ViewBag.NotificationMessage = Carrito.Instancia.EliminarItem((int)idDepartamento);
            return PartialView("_DetalleReserva", Carrito.Instancia.Items);
        }

    }
}
