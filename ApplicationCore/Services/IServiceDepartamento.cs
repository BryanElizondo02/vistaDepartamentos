using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace ApplicationCore.Services
{
    interface IServiceDepartamento
    {
        IEnumerable<DEPARTAMENTO> GetDepartamentos();
        IEnumerable<DEPARTAMENTO> GetDepartamentosActivos();
        IEnumerable<DEPARTAMENTO> GetDepartamentoByUbicacion(String ubicacion);
        IEnumerable<DEPARTAMENTO> GetDepartamentoActivoByUbicacion(String ubicacion);
        DEPARTAMENTO GetDepartamentoByID(int id);
        DEPARTAMENTO GetDepartamentoActivoByID(int id);
        IEnumerable<string> GetDepartamentosUbicaciones();
        void DeleteDEPARTAMENTO(int id);
        DEPARTAMENTO Save(DEPARTAMENTO depart, string[] selectedExtra);

    }
}
