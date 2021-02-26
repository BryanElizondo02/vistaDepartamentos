using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace ApplicationCore.Services
{
    interface IServiceUbicacion
    {
        IEnumerable<UBICACION> GetUbicaciones();
        IEnumerable<UBICACION> GetUbicacionesActivas();
        UBICACION GetUbicacionByID(int id);
        void DeleteUbicacion(int id);
        UBICACION Save(UBICACION ubic);
    }
}
