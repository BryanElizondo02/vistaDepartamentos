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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult UsuariosHabilitados()
        {
            IEnumerable<USUARIO> lista = null;
            try
            {
                ServiceUsuario _serviceUsuario = new ServiceUsuario();
                //lista de opciones de busqueda
                lista = _serviceUsuario.GetUsuarioActivo();

            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData.Keep();
            }
            return View(lista);
        }

        // GET: Usuario
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult UsuariosDeshabilitados()
        {
            IEnumerable<USUARIO> lista = null;
            try
            {
                ServiceUsuario _serviceUsuario = new ServiceUsuario();
                //lista de opciones de busqueda
                lista = _serviceUsuario.GetUsuarioInactivo();

            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData.Keep();
            }
            return View(lista);
        }


        private SelectList listaRol(int idRol = 0)
        {
            ServiceRol _serviceRol = new ServiceRol();
            IEnumerable<ROL> listaRol = _serviceRol.GetRol();

            return new SelectList(listaRol, "Id", "Descripcion", idRol);//List to Dropdown List
        }

        // GET: Usuario/Details/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult DetailsHabilitados(int id)
        {
            return View();
        }

        public ActionResult DetailsDeshabilitados(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create()
        {
            ViewBag.IdRol = listaRol();
            return View();
        }

        [HttpPost]
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("UsuariosHabilitados");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }


        // POST: Usuario/Save
        [HttpPost]
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Save(USUARIO user)
        {
            ServiceUsuario _serviceUsuario = new ServiceUsuario();
            try
            {
                if (ModelState.IsValid)
                {
                    USUARIO oUsuario = _serviceUsuario.Save(user);

                }
                else
                {
                    Util.Util.ValidateErrors(this);
                    ViewBag.IdRol = listaRol();
                    return View("Create", user);
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Usuario";
                TempData["Redirect-Action"] = "UsuariosHabilitados";

                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Usuario/Edit/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult EditHabilitados(int id)
        {
            ServiceUsuario _serviceUsuario = new ServiceUsuario();
            USUARIO oUsuario = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("UsuariosHabilitados");
                }

                oUsuario = _serviceUsuario.GetUsuarioByID(id);
                if (oUsuario == null)
                {
                    TempData["Message"] = "No existe el usuario solicitado";
                    TempData["Redirect"] = "Usuario";
                    TempData["Redirect-Action"] = "UsuariosHabilitados";

                    return RedirectToAction("Default", "Error");
                }
                ViewBag.IdRol = listaRol(oUsuario.IdRol);
                return View(oUsuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Usuario";
                TempData["Redirect-Action"] = "UsuariosHabilitados";

                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Usuario/Edit/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult EditDeshabilitados(int id)
        {
            ServiceUsuario _serviceUsuario = new ServiceUsuario();
            USUARIO oUsuario = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("UsuariosDeshabilitados");
                }

                oUsuario = _serviceUsuario.GetUsuarioByID(id);
                if (oUsuario == null)
                {
                    TempData["Message"] = "No existe el usuario solicitado";
                    TempData["Redirect"] = "Usuario";
                    TempData["Redirect-Action"] = "UsuariosDeshabilitados";

                    return RedirectToAction("Default", "Error");
                }
                ViewBag.IdRol = listaRol(oUsuario.IdRol);
                return View(oUsuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Usuario";
                TempData["Redirect-Action"] = "UsuariosDeshabilitados";

                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Usuario/Delete/5
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [Web.Security.CustomAuthorize((int)Roles.Administrador)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
