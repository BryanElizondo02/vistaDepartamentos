using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Infraestructure.Models;

namespace Infraestructure.Repository
{
    public class RepositoryDepartamento : IRepositoryDepartamento
    {
        public DEPARTAMENTO GetDepartamentoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DEPARTAMENTO> GetDepartamentos()
        {
            try
            {
                IEnumerable<DEPARTAMENTO> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.DEPARTAMENTO.ToList<DEPARTAMENTO>();
                }
                return lista;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception EX)
            {
                string mensaje = "";
                Log.Error(EX, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
    }
}
