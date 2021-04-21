using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;
using Infraestructure.Repository;

namespace ApplicationCore.Services
{
    public class ServiceServicio : IServiceServicio
    {
        public void DeleteServicio(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SERVICIOS> GetServicio()
        {
            IRepositoryServicio repository = new RepositoryServicio();
            return repository.GetServicio();
        }

        public IEnumerable<SERVICIOS> GetServicioActivo()
        {
            IRepositoryServicio repository = new RepositoryServicio();
            return repository.GetServicioActivo();
        }

        public SERVICIOS GetServicioByID(int id)
        {
            IRepositoryServicio repository = new RepositoryServicio();
            return repository.GetServicioByID(id);
        }

        public IEnumerable<SERVICIOS> listaServiciosEscogidos(int[] selectedServicios)
        {
            IRepositoryServicio repository = new RepositoryServicio();
            return repository.listaServiciosEscogidos(selectedServicios);
        }
        public SERVICIOS Save(SERVICIOS servicio)
        {
            IRepositoryServicio repository = new RepositoryServicio();
            return repository.Save(servicio);
        }
    }
}
