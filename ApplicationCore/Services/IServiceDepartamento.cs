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
        DEPARTAMENTO GetDepartamentoByID(int id);
        void DeleteDEPARTAMENTO(bool estado);
        DEPARTAMENTO Save(DEPARTAMENTO depart);

    }
}
