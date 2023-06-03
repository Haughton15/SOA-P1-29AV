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
            Persona persona = new Persona();
            ActivoEmpleadoVM? activoEmpleadoVM = new ActivoEmpleadoVM();
             try
             {
                persona = personaRepositorio.GetPerson(id);
                if(persona.Empleado.ActivoEmpleado != null)
                {
                    activoEmpleadoVM = new ActivoEmpleadoVM
                    {
                        IdEmpleado = (int)persona.Id_Empleado,
                        E_Nombre = persona.Nombre,
                        E_Apellidos = persona.Apellidos,
                        E_Curp = persona.CURP,
                        E_Email = persona.Email,
                        E_FechaNacimiento = persona.FechaNacimiento,
                        E_NumEmp = persona.Empleado.NumEmpleado,
                        IdActivoEmpleado = persona.Empleado.ActivoEmpleado.Id,
                        AE_FechaAsignacion = persona.Empleado.ActivoEmpleado.FechaAsignacion,
                        AE_FechaLiberacion = persona.Empleado.ActivoEmpleado.FechaLiberacion,
                        AE_FechaEntrega = persona.Empleado.ActivoEmpleado.FechaEntrega,
                        IdActivo = persona.Empleado.ActivoEmpleado.Activo.Id,
                        A_Nombre = persona.Empleado.ActivoEmpleado.Activo.Nombre,
                        A_Descripcion = persona.Empleado.ActivoEmpleado.Activo.Descripcion
                    };
                } else {
                    activoEmpleadoVM = new ActivoEmpleadoVM
                    {
                        IdEmpleado = (int)persona.Id_Empleado,
                        E_Nombre = persona.Nombre,
                        E_Apellidos = persona.Apellidos,
                        E_Curp = persona.CURP,
                        E_Email = persona.Email,
                        E_FechaNacimiento = persona.FechaNacimiento,
                        E_NumEmp = persona.Empleado.NumEmpleado
                    };
                }
            }
             catch (Exception e)
             {
                 _logger.LogError(e.Message);
             }
            return activoEmpleadoVM;
         }

    }
}
