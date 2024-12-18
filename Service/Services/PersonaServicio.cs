﻿using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;


namespace Service.Services
{
    public class PersonaServicio : IPersona
    {
        private readonly ILogger<PersonaServicio> _logger;
        public readonly PersonaRepositorio personaRepositorio;

        public PersonaServicio(ILogger<PersonaServicio> logger, ApplicationDbContext context)
        {
            _logger = logger;
            personaRepositorio = new PersonaRepositorio(context);
        }

        public List<Persona> ObtenerLista()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                personas = personaRepositorio.ObtenerLista();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return personas;
        }

        public List<EmpleadoVM> GetEmpleados()
        {
            List<EmpleadoVM> empleadoVMs = new List<EmpleadoVM>();
            try
            {
                empleadoVMs = personaRepositorio.GetEmpleados().Select(x => new EmpleadoVM()
                {
                    Nombre = x.Nombre,
                    Apellidos = x.Apellidos,
                    Area = x.Area.Nombre,
                    Email = x.Correo,
                    NumEmpleado = x.NumEmpleado.ToString()
                }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return empleadoVMs;
        }

        public EmpleadoVM? GetPerson(string correo)
        {
            Empleado? empleado = new Empleado();
            EmpleadoVM? empleadoVM = new EmpleadoVM();
            try
            {
                empleado = personaRepositorio.GetPerson(correo);
                if (empleado != null)
                {
                    empleadoVM.Email = empleado.Correo;
                    empleadoVM.Apellidos = empleado.Apellidos;
                    empleadoVM.Nombre = empleado.Nombre;
                    empleadoVM.Password = empleado.Password;
                }
                Console.WriteLine(correo + " personaservicio");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return empleadoVM;
        }

    }
}
