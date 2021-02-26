using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.Services;
using Infraestructure.Models;

namespace Web.Controllers
{
    public class UbicacionController : Controller
    {
        // GET: Ubicacion
        public ActionResult Ubicaciones()
        {
            IEnumerable<UBICACION> lista = null;
            try
            {
                ServiceUbicacion _serviceUbicacion = new ServiceUbicacion();
                lista = _serviceUbicacion.GetUbicaciones();

            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
            }
            return View(lista);
        }

        public ActionResult Details(int? id)
        {
            ServiceUbicacion _serviceUbicacion = new ServiceUbicacion();
            UBICACION oUbicacion= null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Ubicaciones");
                }

                oUbicacion = _serviceUbicacion.GetUbicacionByID(id.Value);
                if (oUbicacion == null)
                {
                    return RedirectToAction("Ubicaciones");
                }
                return View(oUbicacion);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Ubicaciones");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Edit(int id)
        {
            ServiceUbicacion _serviceUbic = new ServiceUbicacion();
            UBICACION oUbicacion = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Ubicaciones");
                }

                oUbicacion = _serviceUbic.GetUbicacionByID(id);
                if (oUbicacion == null)
                {
                    TempData["Message"] = "No existe la ubicación solicitada";
                    TempData["Redirect"] = "Home";
                    TempData["Redirect-Action"] = "Index";

                    return RedirectToAction("Default", "Error");
                }
                
                return View(oUbicacion);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Ubicacion";
                TempData["Redirect-Action"] = "Ubicaciones";

                return RedirectToAction("Default", "Error");
            }
        }

        [HttpPost]
        public ActionResult Save(UBICACION ubic)
        {
            ServiceUbicacion _serviceUbicacion = new ServiceUbicacion();
            try
            {
                if (ModelState.IsValid)
                {
                    UBICACION oUbicacion = _serviceUbicacion.Save(ubic);

                }
                else
                {
                    Util.Util.ValidateErrors(this);

                    return View("Create", ubic);
                }

                return RedirectToAction("Ubicaciones");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Ubicacion";
                TempData["Redirect-Action"] = "Ubicaciones";

                return RedirectToAction("Default", "Error");
            }
        }

    }
}