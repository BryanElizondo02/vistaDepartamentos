using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Infraestructure.Models;

namespace Infraestructure.Repository
{
    public class RepositoryDepartamento : IRepositoryDepartamento
    {
        public void DeleteDEPARTAMENTO(bool estado)
        {
            int returno;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    /* La carga diferida retrasa la carga de datos relacionados,
                     * hasta que lo solicite específicamente.*/
                    ctx.Configuration.LazyLoadingEnabled = false;
                    DEPARTAMENTO oDepartamento = new DEPARTAMENTO()
                    {
                        Estado = estado

                    };
                    ctx.Entry(oDepartamento).State = EntityState.Modified;
                    returno = ctx.SaveChanges();
                }
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

        public DEPARTAMENTO GetDepartamentoActivoByID(int id)
        {
            DEPARTAMENTO oDepartamento = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oDepartamento = ctx.DEPARTAMENTO.Where(d => d.Id == id && d.Estado == true)
                        .Include(u => u.UBICACION)
                        .Include(x => x.DEPARTAMENTODETALLE)
                        .FirstOrDefault();
                }

                return oDepartamento;
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

        public DEPARTAMENTO GetDepartamentoByID(int id)
        {
            DEPARTAMENTO oDepartamento = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //oDepartamento = ctx.DEPARTAMENTO.Find(id);
                    oDepartamento = ctx.DEPARTAMENTO.Where(d => d.Id == id)
                        .Include(u => u.UBICACION)
                        .Include(x => x.DEPARTAMENTODETALLE)
                        .FirstOrDefault();
                }

                return oDepartamento;
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

        public IEnumerable<DEPARTAMENTO> GetDepartamentos()
        {
            try
            {
                IEnumerable<DEPARTAMENTO> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //lista = ctx.DEPARTAMENTO.Include("UBICACION").ToList<DEPARTAMENTO>();
                    lista = ctx.DEPARTAMENTO
                        .Include(x => x.UBICACION)
                        .Include(d => d.DEPARTAMENTODETALLE)
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
            catch (Exception EX)
            {
                string mensaje = "";
                Log.Error(EX, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<DEPARTAMENTO> GetDepartamentosActivos()
        {
            try
            {
                IEnumerable<DEPARTAMENTO> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.DEPARTAMENTO.Where(x => x.Estado == true)
                        .Include(u => u.UBICACION)
                        .Include(x => x.DEPARTAMENTODETALLE)
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
            catch (Exception EX)
            {
                string mensaje = "";
                Log.Error(EX, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public DEPARTAMENTO Save(DEPARTAMENTO depart)
        {
            int retorno = 0;
            DEPARTAMENTO oDepartamento = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {

                    ctx.Configuration.LazyLoadingEnabled = false;
                    oDepartamento = GetDepartamentoByID(depart.Id);
                    if (oDepartamento == null)
                    {
                        ctx.DEPARTAMENTO.Add(depart);
                    }
                    else
                    {
                        ctx.Entry(depart).State = EntityState.Modified;
                    }
                    retorno = ctx.SaveChanges();
                }

                if (retorno >= 0)
                    oDepartamento = GetDepartamentoByID(depart.Id);

                return oDepartamento;
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
