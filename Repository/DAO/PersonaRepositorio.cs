using Azure.Core;
using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Context;
namespace Repository.DAO
{
    public class PersonaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Persona> ObtenerLista()
        {
            List<Persona> lista = new List<Persona>();

            lista = _context.Personas.Include(x => x.Empleado).ToList();

            return lista;
        }

        public List<Empleado> GetEmpleados()
        {
            List<Empleado> list = new List<Empleado>();

            list = _context.Empleados.ToList();

            return list;
        }

        public ActivoEmpleadoVM GetPerson(int id)
        {
            Persona? persona = new Persona();
            persona = _context.Personas.Include(x => x.Empleado)
                                       .FirstOrDefault(e => e.Id_Empleado == id);

            ActivoEmpleado activoEmpleado = new ActivoEmpleado();
            activoEmpleado = _context.ActivosEmpleados.FirstOrDefault(x => x.IdEmpleado == id);

            ActivoEmpleadoVM activoEmpleadoVM = new ActivoEmpleadoVM
            {
                IdEmpleado = (int)persona.Id_Empleado,
                NombreEmpleado = persona.Nombre,
                ApellidosEmpleado = persona.Apellidos,
                NumEmp = persona.Empleado.NumEmpleado, 
                //Activo = activo,
                activoEmpleado = activoEmpleado
            };
            
            return activoEmpleadoVM;
        }

        public Empleado RegisterEmpleado(PostEmpleadoRequest request)
        {

            Empleado empleado = new Empleado
            {
                NumEmpleado = request.NumEmp,
                Estatus = true,
                FechaIngreso = DateTime.Today
            };
            Console.WriteLine("Register empleado");
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            Console.WriteLine("Save empleado");
            //Cambiar el siguiente a el ultimo guardado
            empleado = _context.Empleados.OrderByDescending(e => e.IdEmpleado).FirstOrDefault();

            Persona persona = new Persona
            {
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                CURP = request.CURP,
                Email = request.Email,
                FechaNacimiento = request.FechaNacimiento,
                Id_Empleado = empleado.IdEmpleado
            };
            Console.WriteLine("Save persona");
            _context.Personas.Add(persona);
            _context.SaveChanges();
            return empleado;
        }
    }
}
