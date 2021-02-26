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
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            IEnumerable<DEPARTAMENTO> lista = null;
            try
            {
                ServiceDepartamento _serviceDepartamento = new ServiceDepartamento();
                lista = _serviceDepartamento.GetDepartamentosActivos();

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
            ServiceDepartamento _serviceDepartamento = new ServiceDepartamento();
            DEPARTAMENTO oDepartamento = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                oDepartamento = _serviceDepartamento.GetDepartamentoActivoByID(id.Value);
                if (oDepartamento == null)
                {
                    TempData["Message"] = "No existe el Departamento solicitado";
                    TempData["Redirect"] = "Home";
                    TempData["Redirect-Action"] = "Index";

                    return RedirectToAction("Default", "Error");
                }
                return View(oDepartamento);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Departamento";
                TempData["Redirect-Action"] = "Departamentos";

                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult buscarUbicacionActivo(String filtro)
        {
            IEnumerable<DEPARTAMENTO> listaDepartamento = null;
            ServiceDepartamento _serviceDepartamento = new ServiceDepartamento();

            if (string.IsNullOrEmpty(filtro))
                listaDepartamento = _serviceDepartamento.GetDepartamentos();
            else
                listaDepartamento = _serviceDepartamento.GetDepartamentoActivoByUbicacion(filtro);

            return PartialView("_PartialViewIndexCatalogo", listaDepartamento);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Equipo de desarrollo:";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Información de Contacto";

            return View();
        }
    }
}