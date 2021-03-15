using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;
using Infraestructure.Repository;

namespace ApplicationCore.Services
{
    public class ServiceTipoPago : IServiceTipoPago
    {
        public void DeleteTipoPago(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TIPOPAGO> GetTipoPago()
        {
            IRepositoryTipoPago repository = new RepositoryTipoPago();
            return repository.GetTipoPago();
        }

        public IEnumerable<TIPOPAGO> GetTipoPagoActivo()
        {
            IRepositoryTipoPago repository = new RepositoryTipoPago();
            return repository.GetTipoPagoActivo();
        }

        public TIPOPAGO GetTipoPagoByID(int id)
        {
            IRepositoryTipoPago repository = new RepositoryTipoPago();
            return repository.GetTipoPagoByID(id);
        }

        public TIPOPAGO Save(TIPOPAGO tipopago)
        {
            IRepositoryTipoPago repository = new RepositoryTipoPago();
            return repository.Save(tipopago);
        }
    }
    
    
}
