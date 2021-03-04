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
    public class RepositoryRol : IRepositoryRol
    {
        public void DeleteRol(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ROL> GetRol()
        {
            try
            {
                IEnumerable<ROL> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.ROL.ToList<ROL>();
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

        public IEnumerable<ROL> GetRolActivo()
        {
            throw new NotImplementedException();
        }

        public ROL GetRolByID(int id)
        {
            ROL oRol = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oRol = ctx.ROL.Find(id);
                }

                return oRol;
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

        public ROL Save(ROL rol)
        {
            int retorno = 0;
            ROL oRol = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {

                    ctx.Configuration.LazyLoadingEnabled = false;
                    oRol = GetRolByID(rol.Id);

                    if (oRol == null)
                    {
                        ctx.ROL.Add(rol);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.ROL.Add(rol);
                        ctx.Entry(rol).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }

                }

                if (retorno >= 0)
                    oRol = GetRolByID(rol.Id);

                return oRol;
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
