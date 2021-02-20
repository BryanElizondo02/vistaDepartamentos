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
    public class RepositoryExtra : IRepositoryExtra
    {
        public EXTRA GetExtraByID(int id)
        {
            EXTRA oExtra = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oExtra = ctx.EXTRA.Find(id);
                }

                return oExtra;
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

        public IEnumerable<EXTRA> GetExtras()
        {
            try
            {
                IEnumerable<EXTRA> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.EXTRA.ToList<EXTRA>();

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

        public EXTRA Save(EXTRA extra)
        {
            int retorno = 0;
            EXTRA oExtra = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {

                    ctx.Configuration.LazyLoadingEnabled = false;
                    oExtra = GetExtraByID((int)extra.Id);


                    if (oExtra == null)
                    {
                        ctx.EXTRA.Add(extra);

                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.EXTRA.Add(extra);
                        ctx.Entry(extra).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }

                }

                if (retorno >= 0)
                    oExtra = GetExtraByID(extra.Id);

                return oExtra;
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
