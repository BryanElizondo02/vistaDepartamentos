using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.Services;
using Infraestructure.Models;
using Web.Enum;

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

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Reservas");
            }
            catch(Exception ex)
            {
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult CreateCatalog(int idDepartamento)
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

                oDepartamento = _serviceDepartamento.GetDepartamentoActivoByID(idDepartamento);
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
    }
}
