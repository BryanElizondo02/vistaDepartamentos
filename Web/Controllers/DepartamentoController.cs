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
                    return RedirectToAction("Departamentos");
                }
                return View(oDepartamento);
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

        

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Departamentos");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Delete(bool estado, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Departamentos");
            }
            catch
            {
                return View();
            }
        }
    }
}