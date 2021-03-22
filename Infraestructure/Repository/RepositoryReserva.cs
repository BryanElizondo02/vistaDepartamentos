using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace Infraestructure.Repository
{
    public class RepositoryReserva : IRepositoryReserva
    {
        public IEnumerable<RESERVA> GetReserva()
        {
            List<RESERVA> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.RESERVA
                        .Include(u => u.USUARIO)
                        .Include(d => d.DEPARTAMENTO)
                        .Include(p => p.TIPOPAGO)
                        .ToList();

                }
                return lista;

            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
        }

        public RESERVA GetReservaByID(int id)
        {
            RESERVA oReserva = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //oDepartamento = ctx.DEPARTAMENTO.Find(id);
                    oReserva = ctx.RESERVA.Where(d => d.Id == id)
                        .Include(u => u.USUARIO)
                        .Include(d => d.DEPARTAMENTO)
                        .Include(p => p.TIPOPAGO)
                        .FirstOrDefault();
                }

                return oReserva;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public RESERVA Save(RESERVA reserv)
        {
            throw new NotImplementedException();
        }
    }
}
