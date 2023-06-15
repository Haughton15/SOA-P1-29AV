using Azure.Core;
using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Repository.Context;
using System.Data;
using BCryptNet = BCrypt.Net.BCrypt;

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
            List<Persona> lista = new();

            lista = _context.Personas.Include(x => x.Empleado).ToList();

            return lista;
        }

        public List<Empleado> GetEmpleados()
        {
            List<Empleado> list = new List<Empleado>();

            list = _context.Empleados.ToList();

            return list;
        }

        public Empleado GetEmpleadoUpdate(int id)
        {
            Empleado empleado = new();

            empleado = _context.Empleados.IgnoreAutoIncludes().FirstOrDefault(x=> x.IdEmpleado==id);

            return empleado;
        }

        public Persona GetPersonUpdate(int id)
        {
            Persona? persona = new Persona();

            persona = _context.Personas.IgnoreAutoIncludes().FirstOrDefault(x => x.Id_Empleado == id);
            return persona;
        }

        public Persona GetPerson(int id)
        {
            Persona? persona = new Persona();
            persona = _context.Personas.Include(x => x.Empleado)
                                        .FirstOrDefault(e => e.Id == id);

            return persona;
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

            string hashedPassword = BCryptNet.HashPassword(request.Password);

            Persona persona = new Persona
            {
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                CURP = request.CURP,
                Email = request.Email,
                FechaNacimiento = request.FechaNacimiento,
                Id_Empleado = empleado.IdEmpleado,
                Password = hashedPassword

            };
            Console.WriteLine("Save persona");
            _context.Personas.Add(persona);
            _context.SaveChanges();
            return empleado;
        }

        public Persona PatchPersona(int id, PatchPersonaRequest request)
        {
            var entityPerson = GetPersonUpdate(id);
            var entityEmpleado = GetEmpleadoUpdate(id);
            DateTime defaultDate = new DateTime(1, 1, 1);

            if (entityPerson == null || entityEmpleado == null)
                return null;

            if(request.Nombre != null)
                entityPerson.Nombre = request.Nombre;

            if(request.Apellidos != null)
                entityPerson.Apellidos = request.Apellidos;

            if(request.CURP != null)
                entityPerson.CURP = request.CURP;

            if(request.Email != null)
                entityPerson.Email = request.Email;

            if(request.FechaNacimiento != defaultDate)
                entityPerson.FechaNacimiento = request.FechaNacimiento;

            if(request.NumEmpleado != 0)
                entityEmpleado.NumEmpleado = request.NumEmpleado;

            if(request.Estatus != entityEmpleado.Estatus)
                entityEmpleado.Estatus = request.Estatus;

            if(request.FechaIngreso != defaultDate)
                entityEmpleado.FechaIngreso = request.FechaIngreso;

            _context.SaveChanges();
            return entityPerson;
        }

        public bool DeletePersona(int id)
        {
            var found = GetPerson(id);
            if (found == null)
            {
                return false;
            }

            Persona? person = new Persona();
            person = _context.Personas.FirstOrDefault(e => e.Id_Empleado == id);

            ActivoEmpleado? activoEmplado = new ActivoEmpleado();
            Activo? activo = new();
            if (activoEmplado.IdPersona == person.Id) {
                activoEmplado = _context.ActivosEmpleados.FirstOrDefault(e => e.IdPersona == person.Id);
                activo = _context.Activos.FirstOrDefault(e => e.Id == activoEmplado.IdActivo);
                activo.Estatus = false;
                _context.Activos.Update(activo);
                _context.ActivosEmpleados.Remove(activoEmplado);
            }

            Empleado? empleado = new Empleado();
            empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == person.Id_Empleado);

            _context.Personas.Remove(person);
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
            return true;
        }

        public Persona GetUserLogin(string correo)
        {
            Persona persona = new Persona();
            persona = _context.Personas.FirstOrDefault(x => x.Email == correo);

            return persona;
        }
    }
}
