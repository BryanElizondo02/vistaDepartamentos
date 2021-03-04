using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace ApplicationCore.Services
{
    interface IServiceRol
    {
        IEnumerable<ROL> GetRol();
        IEnumerable<ROL> GetRolActivo();
        ROL GetRolByID(int id);
        ROL Save(ROL rol);
        void DeleteRol(int id);
    }
}
