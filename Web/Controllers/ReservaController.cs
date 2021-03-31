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
            return View();
        }

        public ActionResult ordenarDepartamento(int? idDepartamento)
        {
            ViewBag.NotiCarrito = Carrito.Instancia.AgregarItem((int)idDepartamento);
            return RedirectToAction("Create");

        }

        private SelectList listTipoPago(int idTipoPago = 0)
        {
            ServiceTipoPago _serviceTipoPago = new ServiceTipoPago();
            IEnumerable<TIPOPAGO> listaTipoPago = _serviceTipoPago.GetTipoPagoActivo();

            return new SelectList(listaTipoPago, "Id", "Nombre", idTipoPago);//List to Dropdown List
        }

        public ActionResult CreateCatalog(int? idDepartamento)
        {
            ServiceDepartamento _serviceDepartamento = new ServiceDepartamento();
            DEPARTAMENTO oDepartamento = null;
            try
            {
                // Si va null
                if (idDepartamento == null)
                {
                    return RedirectToAction("Reservas");
                }
                ViewBag.TipoPago = this.listTipoPago();
                oDepartamento = _serviceDepartamento.GetDepartamentoActivoByID(idDepartamento.Value);
                if (oDepartamento == null)
                {
                    TempData["Message"] = "No existe la reserva solicitada";
                    TempData["Redirect"] = "Reserva";
                    TempData["Redirect-Action"] = "Reservas";

                    return RedirectToAction("Default", "Error");
                }

                return View(oDepartamento);
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

        
        public ActionResult Save(RESERVA reserv, string[] selectedServicio)
        {
            ServiceReserva _serviceReserva = new ServiceReserva();
            try
            {
                if (ModelState.IsValid)
                {
                    RESERVA oReserva = _serviceReserva.Save(reserv, selectedServicio);

                }
                else
                {
                    Util.Util.ValidateErrors(this);

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
