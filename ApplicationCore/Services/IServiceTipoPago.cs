using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace ApplicationCore.Services
{
    public interface IServiceTipoPago
    {
        IEnumerable<TIPOPAGO> GetTipoPago();
        TIPOPAGO GetTipoPagoByID(int id);
        IEnumerable<TIPOPAGO> GetTipoPagoActivo();
        void DeleteTipoPago(int id);
        TIPOPAGO Save(TIPOPAGO tipopago);
    }
}
