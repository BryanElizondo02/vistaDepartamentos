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
        public void DeleteDEPARTAMENTO(bool estado)
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            repository.DeleteDEPARTAMENTO(estado);
        }

        public DEPARTAMENTO GetDepartamentoActivoByID(int id)
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentoActivoByID(id);
        }

        public DEPARTAMENTO GetDepartamentoByID(int id)
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentoByID(id);
        }

        public IEnumerable<DEPARTAMENTO> GetDepartamentos()
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentos();
        }

        public IEnumerable<DEPARTAMENTO> GetDepartamentosActivos()
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentosActivos();
        }

        public DEPARTAMENTO Save(DEPARTAMENTO depart)
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.Save(depart);
        }
    }
}
