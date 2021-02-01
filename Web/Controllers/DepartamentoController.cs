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
    }
}