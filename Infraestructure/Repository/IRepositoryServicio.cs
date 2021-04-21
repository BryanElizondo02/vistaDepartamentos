using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace Infraestructure.Repository
{
    public interface IRepositoryServicio
    {
        IEnumerable<SERVICIOS> GetServicio();
        IEnumerable<SERVICIOS> GetServicioActivo();
        SERVICIOS GetServicioByID(int id);
        IEnumerable<SERVICIOS> listaServiciosEscogidos(int[] selectedServicios);
        SERVICIOS Save(SERVICIOS servicio);
        void DeleteServicio(int id);
    }
}
