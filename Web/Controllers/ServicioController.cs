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
    public class ServicioController : Controller
    {
        // GET: Servicio
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Servicios()
        {
            IEnumerable<SERVICIOS> lista = null;
            try
            {
                ServiceServicio _serviceServicio = new ServiceServicio();
                lista = _serviceServicio.GetServicio();

            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData.Keep();
            }
            return View(lista);
        }

        // GET: Servicio/Details/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Details(int? id)
        {
            ServiceServicio _serviceServicio = new ServiceServicio();
            SERVICIOS oServicio = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Servicios");
                }

                oServicio = _serviceServicio.GetServicioByID(id.Value);
                if (oServicio == null)
                {

                    //return RedirectToAction("Ubicaciones");
                    TempData["Message"] = "No existen los registros solicitados";
                    TempData["Redirect"] = "Servicio";
                    TempData["Redirect-Action"] = "Servicios";

                    return RedirectToAction("Default", "Error");
                }
                return View(oServicio);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "No existen los registros solicitados";
                TempData["Redirect"] = "Servicio";
                TempData["Redirect-Action"] = "Servicios";

                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Servicio/Create
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicio/Create
        [HttpPost]
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Servicios");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Servicio/Edit/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Edit(int id)
        {
            ServiceServicio _serviceServicio = new ServiceServicio();
            SERVICIOS oServicio = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Servicios");
                }

                oServicio = _serviceServicio.GetServicioByID(id);
                if (oServicio == null)
                {
                    TempData["Message"] = "No existe el servicio solicitado";
                    TempData["Redirect"] = "Servicio";
                    TempData["Redirect-Action"] = "Servicios";

                    return RedirectToAction("Default", "Error");
                }

                return View(oServicio);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Servicio";
                TempData["Redirect-Action"] = "Servicios";

                return RedirectToAction("Default", "Error");
            }
        }

        [HttpPost]
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Save(SERVICIOS serv)
        {
            ServiceServicio _serviceServicio = new ServiceServicio();
            try
            {
                if (ModelState.IsValid)
                {
                    SERVICIOS oServicio = _serviceServicio.Save(serv);

                }
                else
                {
                    Util.Util.ValidateErrors(this);

                    return View("Create", serv);
                }

                return RedirectToAction("Servicios");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Servicio";
                TempData["Redirect-Action"] = "Servicios";

                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Servicio/Delete/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Servicio/Delete/5
        [HttpPost]
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Servicios");
            }
            catch
            {
                return View();
            }
        }
    }
}
