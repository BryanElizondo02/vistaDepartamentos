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
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listaEntradasSalidas()
        {
            IEnumerable<RESERVA> lista = null;
            try
            {
                ServiceReserva _serviceReserva = new ServiceReserva();
                lista = _serviceReserva.GetReservaAdmin();

            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos" + ex.Message;
                TempData.Keep();
            }
            return View(lista);
        }

        public ActionResult buscarReserva(DateTime filtro)
        {
            IEnumerable<RESERVA> listaReserva = null;
            ServiceReserva _serviceReserva= new ServiceReserva();

            if (filtro == null)
                listaReserva = _serviceReserva.GetReservaAdmin();
            else
                listaReserva = _serviceReserva.GetReservaEntradasSalidas(filtro);

            return PartialView("_PartialViewReservasEntradasSalidas", listaReserva);
        }

        // GET: Reporte/CreatePDF
        public ActionResult Create()
        {
            return View();
        }
        
        
    }
}
