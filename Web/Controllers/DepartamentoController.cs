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
    public class DepartamentoController : Controller
    {

        // GET: Departamento
        
        public ActionResult Departamentos()
        {
            IEnumerable<DEPARTAMENTO> lista = null;
            try
            {
                ServiceDepartamento _serviceDepartamento = new ServiceDepartamento();
                lista = _serviceDepartamento.GetDepartamentos();
            
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
                    return RedirectToAction("Departamentos");
                }

                oDepartamento = _serviceDepartamento.GetDepartamentoByID(id.Value);
                if (oDepartamento == null)
                {
                    //return RedirectToAction("Departamentos");
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

        public ActionResult buscarUbicacion(String filtro)
        {
            IEnumerable<DEPARTAMENTO> listaDepartamento = null;
            ServiceDepartamento _serviceDepartamento = new ServiceDepartamento();

            if (string.IsNullOrEmpty(filtro))
                listaDepartamento = _serviceDepartamento.GetDepartamentos();
            else
                listaDepartamento = _serviceDepartamento.GetDepartamentoByUbicacion(filtro);

            return PartialView("_PartialViewCatalogo", listaDepartamento);
        }

        private SelectList listUbicacion(int idUbicacion = 0)
        {
            ServiceUbicacion _serviceUbicacion = new ServiceUbicacion();
            IEnumerable<UBICACION> listaUbicacion = _serviceUbicacion.GetUbicacionesActivas();
            return new SelectList(listaUbicacion, "Id", "Nombre", idUbicacion);//List to Dropdown List
        }

        private MultiSelectList listaExtras(ICollection<EXTRA> extras)
        {
            ServiceExtra _serviceExtra = new ServiceExtra();
            IEnumerable<EXTRA> listaExtra = _serviceExtra.GetExtras();
            int[] listaExtraSelect = null;

            if (extras != null)
            {
                listaExtraSelect = extras.Select(e => e.Id).ToArray();
            }

            return new MultiSelectList(listaExtra, "Id", "Descripcion", listaExtraSelect);
        }

        //GET: Departamentos/Create
        public ActionResult Create()
        {
            ViewBag.IdUbicacion = listUbicacion();
            ViewBag.IdExtra = listaExtras(null);
            return View();
        }

        //POST: Departamentos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Departamentos");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Edit(int id)
        {
            ServiceDepartamento _serviceDepartamento = new ServiceDepartamento();
            DEPARTAMENTO oDepartamento = null;
            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Departamentos");
                }

                oDepartamento = _serviceDepartamento.GetDepartamentoByID(id);
                if (oDepartamento == null)
                {
                    //return RedirectToAction("Departamentos");
                    TempData["Message"] = "No existe el Departamento solicitado";
                    TempData["Redirect"] = "Home";
                    TempData["Redirect-Action"] = "Index";

                    return RedirectToAction("Default", "Error");
                }
                ViewBag.IdUbicacion = listUbicacion(oDepartamento.IdUbicacion);
                ViewBag.IdExtra = listaExtras(oDepartamento.EXTRA);
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

        [HttpPost]
        public ActionResult Save(DEPARTAMENTO departamento, string []selectedExtra)
        {
            ServiceDepartamento _serviceDepartamento = new ServiceDepartamento();
            try
            {
                if (ModelState.IsValid)
                {
                    DEPARTAMENTO oDepartamento = _serviceDepartamento.Save(departamento, selectedExtra);
                    

                }
                else
                {
                    Util.Util.ValidateErrors(this);
                    ViewBag.IdUbicacion = listUbicacion();
                    ViewBag.IdExtra = listaExtras(departamento.EXTRA);

                    return View("Create", departamento);
                }

                return RedirectToAction("Departamentos");
            }
            catch(Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData["Redirect"] = "Departamento";
                TempData["Redirect-Action"] = "Departamentos";

                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Departamentos");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }
    }
}