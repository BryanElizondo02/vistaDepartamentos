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
        RESERVA GetReservaByID(int id);
        RESERVA Save(RESERVA reserv, string[] selectedServicios);
    }
}
