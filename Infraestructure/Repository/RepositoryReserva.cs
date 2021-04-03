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
        public IEnumerable<RESERVA> GetReserva(int usuario)
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
                        .Include(d => d.SERVICIOS)
                        .Include(p => p.TIPOPAGO)
                        .Where(x => x.IdUsuario == usuario)
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

        public IEnumerable<RESERVA> GetReservaAdmin()
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
                        .Include(d => d.SERVICIOS)
                        .Include(p => p.TIPOPAGO)
                        .OrderByDescending(o => o.FechaReserva)
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
                    
                    oReserva = ctx.RESERVA.Where(d => d.Id == id)
                        .Include(u => u.USUARIO)
                        .Include(d => d.DEPARTAMENTO)
                        .Include(d => d.SERVICIOS)
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

        public RESERVA GetReservaByRangoFechas(DateTime date1, DateTime date2, int idDepartamento)
        {
            RESERVA oReserva = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    oReserva = ctx.RESERVA.Where(d => d.FechaReserva >= date1 
                    && d.FechaFinReserva <= date2 && d.DEPARTAMENTO.Id == idDepartamento)
                        .Include(u => u.USUARIO)
                        .Include(d => d.DEPARTAMENTO)
                        .Include(d => d.SERVICIOS)
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

        public RESERVA Save(RESERVA reserv, string [] selectedServicios)
        {
            int retorno = 0;
            RESERVA oReseva = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    using (var transaccion = ctx.Database.BeginTransaction())
                    {
                        ctx.Configuration.LazyLoadingEnabled = false;
                        oReseva = GetReservaByID((int)reserv.Id);
                        RepositoryServicio _repositoryServicio = new RepositoryServicio();

                        if (oReseva == null)
                        {
                            //Insertar
                            if (selectedServicios != null)
                            {
                                reserv.SERVICIOS = new List<SERVICIOS>();

                                foreach (var serv in selectedServicios)
                                {
                                    var servAdd = _repositoryServicio.GetServicioByID(int.Parse(serv));
                                    ctx.SERVICIOS.Attach(servAdd);
                                    reserv.SERVICIOS.Add(servAdd);

                                }
                            }

                            ctx.RESERVA.Add(reserv);

                            retorno = ctx.SaveChanges();
                        }
                        else
                        {
                            ctx.RESERVA.Add(reserv);
                            ctx.Entry(reserv).State = EntityState.Modified;
                            retorno = ctx.SaveChanges();

                            var selectedServiciosId = new HashSet<string>(selectedServicios);
                            if (selectedServicios != null)
                            {
                                ctx.Entry(reserv).Collection(p => p.SERVICIOS).Load();
                                var newServiReserv = ctx.SERVICIOS
                                    .Where(x => selectedServiciosId.Contains(x.Id.ToString())).ToList();

                                reserv.SERVICIOS = newServiReserv;

                                ctx.Entry(reserv).State = EntityState.Modified;
                                retorno = ctx.SaveChanges();
                            }
                        }

                        // Commit 
                        transaccion.Commit();
                    } 
                }

                if (retorno >= 0)
                    oReseva = GetReservaByID(reserv.Id);

                return oReseva;
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
