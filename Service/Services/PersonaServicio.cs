using Domain.Entities;
using Domain.Models.Requests;
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
                empleadoVMs = personaRepositorio.ObtenerLista().Select(x => new EmpleadoVM()
                {
                    ID = x.Empleado.IdEmpleado,
                    Nombre = x.Nombre,
                    Apellidos = x.Apellidos
                }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return empleadoVMs;
        }

        public Empleado RegisterEmpleado(PostEmpleadoRequest request)
        {
            var response = personaRepositorio.RegisterEmpleado(request);
            return response;
        }

        public ActivoEmpleadoVM? GetPerson(int id)
         {
            ActivoEmpleadoVM activoEmpleadoVM = new ActivoEmpleadoVM();
             try
             {
                activoEmpleadoVM = personaRepositorio.GetPerson(id);
                 //Console.WriteLine(correo + " personaservicio");
             }
             catch (Exception e)
             {
                 _logger.LogError(e.Message);
             }

             return activoEmpleadoVM;
         }

    }
}
