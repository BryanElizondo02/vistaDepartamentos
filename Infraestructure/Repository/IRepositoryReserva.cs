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
        RESERVA GetReservaByID(int id);
        RESERVA Save(RESERVA reserv, string[] selectedServicios);
    }
}
