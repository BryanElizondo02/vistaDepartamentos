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
    public class UsuarioController : Controller
    {
        // GET: Usuario
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
            IEnumerable<ROL> listaUbicacion = _serviceRol.GetRol();

            return new SelectList(listaUbicacion, "Id", "Descripcion", idRol);//List to Dropdown List
        }

        // GET: Usuario/Details/5
        public ActionResult DetailsHabilitados(int id)
        {
            return View();
        }

        public ActionResult DetailsDeshabilitados(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.IdRol = listaRol();
            return View();
        }

        [HttpPost]
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

        // POST: Usuario/Create
        [HttpPost]
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

                return RedirectToAction("UsuariosHabilitados");
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
        public ActionResult EditHabilitados(int id)
        {
            return View();
        }

        // GET: Usuario/Edit/5
        public ActionResult EditDeshabilitados(int id)
        {
            return View();
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
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
