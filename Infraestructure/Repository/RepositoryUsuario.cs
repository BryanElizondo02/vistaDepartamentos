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
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public USUARIO GetUsuario(string email, string password)
        {
            USUARIO oUsuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oUsuario = ctx.USUARIO.
                     Where(p => p.Correo.Equals(email) && p.Clave == password).
                    FirstOrDefault<USUARIO>();
                }
                if (oUsuario != null)
                    oUsuario = GetUsuarioByID(oUsuario.Id);
                return oUsuario;
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

        public IEnumerable<USUARIO> GetUsuarioActivo()
        {
            try
            {
                IEnumerable<USUARIO> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.USUARIO.Where(x => x.Estado == true)
                        .Include(u => u.ROL)
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

        public USUARIO GetUsuarioByID(int id)
        {
            USUARIO usuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    usuario = ctx.USUARIO.
                     Include("ROL").
                    Where(p => p.Id == id).
                    FirstOrDefault<USUARIO>();
                }
                return usuario;
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

        public IEnumerable<USUARIO> GetUsuarioInactivo()
        {
            try
            {
                IEnumerable<USUARIO> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.USUARIO.Where(x => x.Estado == false)
                        .Include(u => u.ROL)
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

        public USUARIO Save(USUARIO usuario)
        {
            int retorno = 0;
            USUARIO oUsuario = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    oUsuario = GetUsuarioByID(usuario.Id);
                    if (oUsuario == null)
                    {
                        ctx.USUARIO.Add(usuario);
                    }
                    else
                    {
                        ctx.Entry(usuario).State = EntityState.Modified;
                    }
                    retorno = ctx.SaveChanges();
                }
                if (retorno >= 0)
                    oUsuario = GetUsuarioByID(usuario.Id);
                return oUsuario;
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
