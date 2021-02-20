using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace Infraestructure.Repository
{
    public interface IRepositoryUbicacion
    {
        IEnumerable<UBICACION> GetUbicaciones();
        UBICACION GetUbicacionByID(int id);
        void DeleteUbicacion(int id);
        UBICACION Save(UBICACION ubic);
    }
}
