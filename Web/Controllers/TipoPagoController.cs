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
    public class TipoPagoController : Controller
    {
        // GET: TipoPago
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult TiposPagos()
        {
            IEnumerable<TIPOPAGO> lista = null;
            try
            {
                ServiceTipoPago _serviceTipoPago = new ServiceTipoPago();
                lista = _serviceTipoPago.GetTipoPago();

            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData.Keep();
            }
            return View(lista);
        }

        // GET: TipoPago/Details/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Details(int? id)
        {
            ServiceTipoPago _serviceTipoPago = new ServiceTipoPago();
            TIPOPAGO otipopago = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("TiposPagos");
                }

                otipopago = _serviceTipoPago.GetTipoPagoByID(id.Value);
                if (otipopago == null)
                {

                    //return RedirectToAction("Ubicaciones");
                    TempData["Message"] = "No existe la Ubicación solicitada";
                    TempData["Redirect"] = "TipoPago";
                    TempData["Redirect-Action"] = "TiposPagos";

                    return RedirectToAction("Default", "Error");
                }
                return View(otipopago);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "TipoPago";
                TempData["Redirect-Action"] = "TiposPagos";

                return RedirectToAction("Default", "Error");
            }
        }

        // GET: TipoPago/Create
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPago/Create
        [HttpPost]
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("TiposPagos");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: TipoPago/Edit/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Edit(int id)
        {
            ServiceTipoPago _serviceTipoPago = new ServiceTipoPago();
            TIPOPAGO otipopago = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Ubicaciones");
                }

                otipopago = _serviceTipoPago.GetTipoPagoByID(id);
                if (otipopago == null)
                {
                    TempData["Message"] = "No existe la ubicación solicitada";
                    TempData["Redirect"] = "TipoPago";
                    TempData["Redirect-Action"] = "TiposPagos";

                    return RedirectToAction("Default", "Error");
                }

                return View(otipopago);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "TipoPago";
                TempData["Redirect-Action"] = "TiposPagos";

                return RedirectToAction("Default", "Error");
            }
        }

        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Save(TIPOPAGO tp)
        {
            ServiceTipoPago _serviceTipoPago = new ServiceTipoPago();
            try
            {
                if (ModelState.IsValid)
                {
                    TIPOPAGO otipopago = _serviceTipoPago.Save(tp);

                }
                else
                {
                    Util.Util.ValidateErrors(this);

                    return View("Create", tp);
                }

                return RedirectToAction("TiposPagos");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "TipoPago";
                TempData["Redirect-Action"] = "TiposPagos";

                return RedirectToAction("Default", "Error");
            }
        }

    }
}
