using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;
using Infraestructure.Repository;

namespace ApplicationCore.Services
{
    public class ServiceReserva : IServiceReserva
    {
        public IEnumerable<RESERVA> GetReserva(int usuario)
        {
            IRepositoryReserva repository = new RepositoryReserva();
            return repository.GetReserva(usuario);
        }

        public IEnumerable<RESERVA> GetReservaAdmin()
        {
            IRepositoryReserva repository = new RepositoryReserva();
            return repository.GetReservaAdmin();
        }

        public RESERVA GetReservaByID(int id)
        {
            IRepositoryReserva repository = new RepositoryReserva();
            return repository.GetReservaByID(id);
        }

        public RESERVA Save(RESERVA reserv, string[] selectedServicios)
        {
            IRepositoryReserva repository = new RepositoryReserva();
            return repository.Save(reserv, selectedServicios);
        }
    }
}
