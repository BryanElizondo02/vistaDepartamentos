﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;
using Infraestructure.Repository;

namespace ApplicationCore.Services
{
    public class ServiceDepartamento : IServiceDepartamento
    {
        public void DeleteDEPARTAMENTO(int id)
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            repository.DeleteDEPARTAMENTO(id);
        }

        public DEPARTAMENTO GetDepartamentoActivoByID(int id)
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentoActivoByID(id);
        }

        public IEnumerable<DEPARTAMENTO> GetDepartamentoActivoByUbicacion(string ubicacion)
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentoActivoByUbicacion(ubicacion);
        }

        public DEPARTAMENTO GetDepartamentoByID(int id)
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentoByID(id);
        }

        public IEnumerable<DEPARTAMENTO> GetDepartamentoByUbicacion(string ubicacion)
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentoByUbicacion(ubicacion);
        }

        public IEnumerable<DEPARTAMENTO> GetDepartamentos()
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentos();
        }

        public IEnumerable<DEPARTAMENTO> GetDepartamentosActivos()
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentosActivos();
        }

        public IEnumerable<string> GetDepartamentosUbicaciones()
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.GetDepartamentosUbicaciones();
        }

        public DEPARTAMENTO Save(DEPARTAMENTO depart, string[] selectedExtra)
        {
            IRepositoryDepartamento repository = new RepositoryDepartamento();
            return repository.Save(depart, selectedExtra);
        }
    }
}
