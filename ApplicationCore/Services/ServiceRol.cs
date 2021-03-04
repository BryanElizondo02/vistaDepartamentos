using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;
using Infraestructure.Repository;

namespace ApplicationCore.Services
{
    public class ServiceRol : IServiceRol
    {
        public void DeleteRol(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ROL> GetRol()
        {
            IRepositoryRol _repository = new RepositoryRol();
            return _repository.GetRol();
        }

        public IEnumerable<ROL> GetRolActivo()
        {
            throw new NotImplementedException();
        }

        public ROL GetRolByID(int id)
        {
            IRepositoryRol _repository = new RepositoryRol();
            return _repository.GetRolByID(id);
        }

        public ROL Save(ROL rol)
        {
            IRepositoryRol _repository = new RepositoryRol();
            return _repository.Save(rol);
        }
    }
}
