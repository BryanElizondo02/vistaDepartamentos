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
    public class RepositoryServicio : IRepositoryServicio
    {
        public void DeleteServicio(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SERVICIOS> GetServicio()
        {
            try
            {
                IEnumerable<SERVICIOS> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.SERVICIOS.ToList<SERVICIOS>();
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

        public IEnumerable<SERVICIOS> GetServicioActivo()
        {
            try
            {
                IEnumerable<SERVICIOS> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.SERVICIOS.Where(x => x.Estado == true).ToList();
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

        public SERVICIOS GetServicioByID(int id)
        {
            SERVICIOS oServicio = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oServicio = ctx.SERVICIOS.Find(id);
                }

                return oServicio;
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

        public IEnumerable<SERVICIOS> listaServiciosEscogidos(int[] selectedServicios)
        {

            try
            {
                IEnumerable<SERVICIOS> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    if (selectedServicios != null)
                    {
                        lista = new List<SERVICIOS>();
                        foreach (var serv in selectedServicios)
                        {
                            SERVICIOS servAdd = this.GetServicioByID(serv);
                            lista.Append(servAdd);
                        }
                    }
                        
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

        public SERVICIOS Save(SERVICIOS servicio)
        {
            int retorno = 0;
            SERVICIOS oServicio = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {

                    ctx.Configuration.LazyLoadingEnabled = false;
                    oServicio = GetServicioByID((int)servicio.Id);

                    if (oServicio == null)
                    {
                        ctx.SERVICIOS.Add(servicio);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.SERVICIOS.Add(servicio);
                        ctx.Entry(servicio).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }

                }

                if (retorno >= 0)
                    oServicio = GetServicioByID(servicio.Id);

                return oServicio;
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
