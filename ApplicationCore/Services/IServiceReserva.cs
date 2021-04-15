using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace ApplicationCore.Services
{
    public interface IServiceReserva
    {
        IEnumerable<RESERVA> GetReserva(int usuario);
        IEnumerable<RESERVA> GetReservaAdmin();
        RESERVA GetReservaByRangoFechas(DateTime date1, DateTime date2, int idDepartamento);
        void GetReservaCountDate(out string etiquetas, out string valores, DateTime fecha);
        RESERVA GetReservaByID(int id);
        IEnumerable<RESERVA> GetReservaEntradasSalidas(DateTime date1);
        RESERVA Save(RESERVA reserv, string[] selectedServicios);
    }
}
