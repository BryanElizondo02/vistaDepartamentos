using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace Infraestructure.Repository
{
    public interface IRepositoryExtra
    {
        IEnumerable<EXTRA> GetExtras();
        EXTRA GetExtraByID(int id);
        EXTRA Save(EXTRA extra);
    }
}
