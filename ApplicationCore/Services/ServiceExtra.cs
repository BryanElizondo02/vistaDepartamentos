using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;
using Infraestructure.Repository;

namespace ApplicationCore.Services
{
    public class ServiceExtra : IServiceExtra
    {
        public void DeleteExtra(int id)
        {
            throw new NotImplementedException();
        }

        public EXTRA GetExtraByID(int id)
        {
            IRepositoryExtra repository = new RepositoryExtra();
            return repository.GetExtraByID(id);
        }

        public IEnumerable<EXTRA> GetExtras()
        {
            IRepositoryExtra repository = new RepositoryExtra();
            return repository.GetExtras();
        }

        public IEnumerable<EXTRA> GetExtrasActivo()
        {
            IRepositoryExtra repository = new RepositoryExtra();
            return repository.GetExtrasActivo();
        }

        public EXTRA Save(EXTRA extra)
        {
            IRepositoryExtra repository = new RepositoryExtra();
            return repository.Save(extra);
        }
    }
}
