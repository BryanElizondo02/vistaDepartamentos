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
    }
}