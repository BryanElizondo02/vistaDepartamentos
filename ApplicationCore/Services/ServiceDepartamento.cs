using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;
using Infraestructure.Repository;

namespace ApplicationCore.Services
{
    public class ServiceDepartamento : IServiceDepartamento
    {
        public DEPARTAMENTO GetDepartamentoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DEPARTAMENTO> GetDepartamentos()
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentos();
        }
    }
}
