using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace Infraestructure.Repository
{
    public interface IRepositoryReserva
    {
        IEnumerable<RESERVA> GetReserva(int usuario);
        IEnumerable<RESERVA> GetReservaAdmin();
        void GetReservaCountDate(out string etiquetas, out string valores, DateTime fecha);
        RESERVA GetReservaByID(int id);
        IEnumerable<RESERVA> GetReservaEntradasSalidas(DateTime date1);
        RESERVA GetReservaByRangoFechas(DateTime date1, DateTime date2, int idDepartamento);
        RESERVA Save(RESERVA reserv, string[] selectedServicios);
    }
}
