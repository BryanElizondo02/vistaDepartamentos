using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Utils;
using Infraestructure.Models;
using Infraestructure.Repository;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public USUARIO CrearCuenta(USUARIO usuario)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            usuario.Clave = Cryptography.EncrypthAES(usuario.Clave);
            usuario.Estado = false;
            usuario.IdRol = 2;
            return repository.CrearCuenta(usuario);
        }

        public USUARIO GetUsuario(string email, string password)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            // Encriptar el password para poder compararlo
            string crytpPasswd = Cryptography.EncrypthAES(password);
            return repository.GetUsuario(email, crytpPasswd);

        }

        public IEnumerable<USUARIO> GetUsuarioActivo()
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            return repository.GetUsuarioActivo();
        }

        public USUARIO GetUsuarioByID(int id)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            USUARIO oUsuario = repository.GetUsuarioByID(id);
            oUsuario.Clave = Cryptography.DecrypthAES(oUsuario.Clave);
            return oUsuario;

        }

        public IEnumerable<USUARIO> GetUsuarioInactivo()
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            return repository.GetUsuarioInactivo();
        }

        public USUARIO Save(USUARIO usuario)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            usuario.Clave = Cryptography.EncrypthAES(usuario.Clave);
            return repository.Save(usuario);

        }
    }
}
