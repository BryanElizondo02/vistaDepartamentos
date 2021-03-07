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
    public class ExtraController : Controller
    {
        // GET: Extra
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Extras()
        {
            IEnumerable<EXTRA> lista = null;
            try
            {
                ServiceExtra _serviceExtra = new ServiceExtra();
                lista = _serviceExtra.GetExtras();

            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData.Keep();
            }
            return View(lista);
        }

        // GET: Extra/Details/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Details(int? id)
        {
            ServiceExtra _serviceExtra = new ServiceExtra();
            EXTRA oExtra = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Extras");
                }

                oExtra = _serviceExtra.GetExtraByID(id.Value);
                if (oExtra == null)
                {

                    //return RedirectToAction("Ubicaciones");
                    TempData["Message"] = "No existen los registros solicitados";
                    TempData["Redirect"] = "Extra";
                    TempData["Redirect-Action"] = "Extras";

                    return RedirectToAction("Default", "Error");
                }
                return View(oExtra);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "No existen los registros solicitados";
                TempData["Redirect"] = "Extra";
                TempData["Redirect-Action"] = "Extras";

                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Extra/Create
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Extra/Create
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Extras");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Extra/Edit/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Edit(int id)
        {
            ServiceExtra _serviceExtra = new ServiceExtra();
            EXTRA oExtra = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Extras");
                }

                oExtra = _serviceExtra.GetExtraByID(id);
                if (oExtra == null)
                {
                    TempData["Message"] = "No existen los registros solicitados";
                    TempData["Redirect"] = "Extra";
                    TempData["Redirect-Action"] = "Extras";

                    return RedirectToAction("Default", "Error");
                }

                return View(oExtra);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "No existen los registros solicitados";
                TempData["Redirect"] = "Extra";
                TempData["Redirect-Action"] = "Extras";

                return RedirectToAction("Default", "Error");
            }
        }

        [HttpPost]
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Save(EXTRA ext)
        {
            ServiceExtra _serviceExtra = new ServiceExtra();
            try
            {
                if (ModelState.IsValid)
                {
                    EXTRA oExtra = _serviceExtra.Save(ext);

                }
                else
                {
                    Util.Util.ValidateErrors(this);

                    return View("Create", ext);
                }

                return RedirectToAction("Extras");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "No existen los registros solicitados";
                TempData["Redirect"] = "Extra";
                TempData["Redirect-Action"] = "Extras";

                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Extra/Delete/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Extra/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Extras");
            }
            catch
            {
                return View();
            }
        }
    }
}
