﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;

namespace ApplicationCore.Services
{
    interface IServiceExtra
    {
        IEnumerable<EXTRA> GetExtras();
        EXTRA GetExtraByID(int id);
        EXTRA Save(EXTRA extra);
    }
}