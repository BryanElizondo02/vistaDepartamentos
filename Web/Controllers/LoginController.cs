using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.Services;
using Infraestructure.Models;
using Web.Util;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(USUARIO user)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            USUARIO oUsuario = null;
            try
            {
                if (ModelState.IsValid)
                {
                    oUsuario = _ServiceUsuario.GetUsuario(user.Correo, user.Clave);

                    if (oUsuario != null)
                    {
                        Session["User"] = oUsuario;
                        Log.Info($"Accede {oUsuario.Nombre} {oUsuario.Apellido1} con el rol {oUsuario.ROL.Id}-{oUsuario.ROL.Descripcion}");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Log.Warn($"{user.Correo} se intentó conectar  y falló");
                        ViewBag.NotificationMessage = Util.SweetAlertHelper.Mensaje("Login", "Error al autenticarse", SweetAlertMessageType.warning);

                    }
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                // Pasar el Error a la página que lo muestra
                TempData["Message"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult UnAuthorized()
        {
            try
            {
                ViewBag.Message = "No autorizado";

                if (Session["User"] != null)
                {
                    USUARIO oUsuario = Session["User"] as USUARIO;
                    Log.Warn($"El usuario {oUsuario.Nombre} {oUsuario.Apellido1} con el rol {oUsuario.ROL.Id}-{oUsuario.ROL.Descripcion}, intentó acceder una página sin permisos  ");
                }

                return View();
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                // Pasar el Error a la página que lo muestra
                TempData["Message"] = ex.Message;
                TempData["Redirect"] = "Login";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
        }


        public ActionResult Logout()
        {
            try
            {
                Log.Info("Usuario desconectado!");
                Session["User"] = null;
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                // Pasar el Error a la página que lo muestra
                TempData["Message"] = ex.Message;
                TempData["Redirect"] = "Login";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
        }

       
    }
}
