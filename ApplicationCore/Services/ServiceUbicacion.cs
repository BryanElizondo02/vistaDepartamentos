using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;
using Infraestructure.Repository;

namespace ApplicationCore.Services
{
    public class ServiceUbicacion : IServiceUbicacion
    {
        public void DeleteUbicacion(int id)
        {
            IRepositoryUbicacion repository = new RepositoryUbicacion();
            repository.DeleteUbicacion(id);
        }


        public UBICACION GetUbicacionByID(int id)
        {
            IRepositoryUbicacion repository = new RepositoryUbicacion();
            return repository.GetUbicacionByID(id);
        }

        public IEnumerable<UBICACION> GetUbicaciones()
        {
            IRepositoryUbicacion repository = new RepositoryUbicacion();
            return repository.GetUbicaciones();
        }

        public IEnumerable<UBICACION> GetUbicacionesActivas()
        {
            IRepositoryUbicacion repository = new RepositoryUbicacion();
            return repository.GetUbicacionesActivas();
        }

        public UBICACION Save(UBICACION ubic)
        {
            IRepositoryUbicacion repository = new RepositoryUbicacion();
            return repository.Save(ubic);
        }
    }
}
