using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace Infraestructure.Repository
{
    public class RepositoryTipoPago : IRepositoryTipoPago
    {
        public void DeleteTipoPago(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TIPOPAGO> GetTipoPago()
        {
            try
            {
                IEnumerable<TIPOPAGO> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.TIPOPAGO.ToList<TIPOPAGO>();
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

        public IEnumerable<TIPOPAGO> GetTipoPagoActivo()
        {
            try
            {
                IEnumerable<TIPOPAGO> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.TIPOPAGO.Where(x => x.Estado == true).ToList();
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

        public TIPOPAGO GetTipoPagoByID(int id)
        {
            TIPOPAGO otipopago = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    otipopago = ctx.TIPOPAGO.Find(id);
                }

                return otipopago;
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

        public TIPOPAGO Save(TIPOPAGO tipopago)
        {
            int retorno = 0;
            TIPOPAGO otipopago = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {

                    ctx.Configuration.LazyLoadingEnabled = false;
                    otipopago = GetTipoPagoByID(tipopago.Id);

                    if (otipopago == null)
                    {
                        ctx.TIPOPAGO.Add(tipopago);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.TIPOPAGO.Add(tipopago);
                        ctx.Entry(tipopago).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }

                }

                if (retorno >= 0)
                    otipopago = GetTipoPagoByID(tipopago.Id);

                return otipopago;
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
    }
}
