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
                /*if (ModelState.IsValid)
                {*/
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
                //}

                return View("Index");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                // Pasar el Error a la página que lo muestra
                TempData["Message"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("Default", "Login");
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
                return RedirectToAction("Default", "Login");
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
                return RedirectToAction("Default", "Login");
            }
        }

        public ActionResult Error(Exception ex)
        {
            //controller
            String redirect = "Login";
            //action controller
            String redirectAction = "Index";

            HttpException httpException = ex as HttpException;
            //Obtener el codigo de estado HTTP
            int error = httpException != null ? httpException.GetHttpCode() : 0;

            switch (error)
            {
                case 400:
                    ViewBag.Title = "Solicitud incorrecta";
                    ViewBag.Description = "El servidor no pudo interpretar la solicitud dada una sintaxis inválida.";
                    break;

                case 401:
                    ViewBag.Title = "No autorizado";
                    ViewBag.Description = "Es necesario autenticar el usuario para obtener la respuesta solicitada";
                    break;
                case 403:
                    ViewBag.Title = "Acceso restringido";
                    ViewBag.Description = "El usuario no posee los permisos necesarios para el contenido";
                    break;
                default:
                    ViewBag.Title = error + " Error";
                    ViewBag.Description = ex.Message;
                    break;
            }
            ViewBag.redirect = redirect;
            ViewBag.redirectAction = redirectAction;
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }


        public ActionResult Default()
        {
            //Controlador
            String redirect = "Login";
            //Acción de controlador
            String redirectAction = "Index";
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Title = "Error";
                ViewBag.Description = TempData["Message"];
                if (TempData.ContainsKey("Redirect"))
                {
                    redirect = (String)TempData["Redirect"];
                }
                if (TempData.ContainsKey("Redirect-Action"))
                {
                    redirectAction = (String)TempData["Redirect-Action"];
                }
                ViewBag.redirect = redirect;
                ViewBag.redirectAction = redirectAction;
                return View("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}
