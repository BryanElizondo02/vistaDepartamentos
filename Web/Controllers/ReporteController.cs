using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ApplicationCore.Services;
using Infraestructure.Models;
using Web.Security;
using Web.Enum;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Layout.Properties;

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
                ViewBag.fecha = lista;
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
            ServiceReserva _serviceReserva = new ServiceReserva();

            if (filtro == null)
            {
                listaReserva = _serviceReserva.GetReservaAdmin();
            }
            else
            {
                listaReserva = _serviceReserva.GetReservaEntradasSalidas(filtro);
                ViewBag.fechaReserva = filtro;
            }

            return PartialView("_PartialViewReservasEntradasSalidas", listaReserva);
        }

        public IEnumerable<RESERVA> buscarReservaPDF(DateTime filtro)
        {

            IEnumerable<RESERVA> listaReserva = null;
            ServiceReserva _serviceReserva = new ServiceReserva();

            if (filtro == null)
            {
                listaReserva = _serviceReserva.GetReservaAdmin();
            }
            else
            {
                listaReserva = _serviceReserva.GetReservaEntradasSalidas(filtro);

            }

            return listaReserva;
        }

        // GET: Reporte/CreatePdfReporte
        [CustomAuthorize((int)Enum.Roles.Administrador, (int)Enum.Roles.Reportes)]
        public ActionResult CreatePdfReporte(DateTime fecha)
        {
            //Ejemplos IText7 https://kb.itextpdf.com/home/it7kb/examples
            IEnumerable<RESERVA> lista = null;
            try
            {
                // Extraer informacion
                ServiceReserva _serviceReserva = new ServiceReserva();
                lista = _serviceReserva.GetReservaEntradasSalidas(fecha);

                // Crear stream para almacenar en memoria el reporte 
                MemoryStream ms = new MemoryStream();
                //Initialize writer
                PdfWriter writer = new PdfWriter(ms);

                //Initialize document
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document doc = new Document(pdfDoc);

                Paragraph header = new Paragraph("Historial de Reservas")
                                   .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                                   .SetFontSize(14)
                                   .SetFontColor(ColorConstants.BLUE);
                doc.Add(header);


                // Crear tabla con 5 columnas 
                Table table = new Table(10, true);


                // los Encabezados
                table.AddHeaderCell("Cliente");
                table.AddHeaderCell("Departamento");
                table.AddHeaderCell("Fecha de Reservación");
                table.AddHeaderCell("Fin de Reservación");
                table.AddHeaderCell("Medio de pago");
                table.AddHeaderCell("N° Tarjeta");
                table.AddHeaderCell("Cantidad de personas");
                table.AddHeaderCell("Subtotal");
                table.AddHeaderCell("Impuesto");
                table.AddHeaderCell("Total");


                foreach (var item in lista)
                {

                    // Agregar datos a las celdas
                    table.AddCell(new Paragraph(item.USUARIO.Nombre));
                    table.AddCell(new Paragraph(item.DEPARTAMENTO.Nombre));
                    table.AddCell(new Paragraph(item.FechaReserva.ToString()));
                    table.AddCell(new Paragraph(item.FechaFinReserva.ToString()));
                    table.AddCell(new Paragraph(item.TIPOPAGO.Nombre));
                    table.AddCell(new Paragraph(item.NumeroTarjeta));
                    table.AddCell(new Paragraph(item.CantPersonas.ToString()));
                    table.AddCell(new Paragraph(item.SubTotal.ToString()));
                    table.AddCell(new Paragraph(item.Impuesto.ToString()));
                    table.AddCell(new Paragraph(item.Total.ToString()));

                }
                doc.Add(table);



                // Colocar número de páginas
                int numberOfPages = pdfDoc.GetNumberOfPages();
                for (int i = 1; i <= numberOfPages; i++)
                {

                    // Write aligned text to the specified by parameters point
                    doc.ShowTextAligned(new Paragraph(String.Format("pag {0} of {1}", i, numberOfPages)),
                            559, 826, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
                }


                //Close document
                doc.Close();
                // Retorna un File
                return File(ms.ToArray(), "application/pdf", "reporte.pdf");

            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData.Keep();
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        
        
    }
}
