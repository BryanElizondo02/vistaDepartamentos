using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace ApplicationCore.Services
{
    public interface IServiceUsuario
    {
        USUARIO GetUsuarioByID(int id);
        USUARIO Save(USUARIO usuario);
        USUARIO GetUsuario(string email, string password);
        IEnumerable<USUARIO> GetUsuarioActivo();
        IEnumerable<USUARIO> GetUsuarioInactivo();
    }
}
