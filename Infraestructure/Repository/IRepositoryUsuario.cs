using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace Infraestructure.Repository
{
    public interface IRepositoryUsuario
    {
        USUARIO GetUsuarioByID(int id);
        USUARIO Save(USUARIO usuario);
        USUARIO GetUsuario(string email, string password);


    }
}
