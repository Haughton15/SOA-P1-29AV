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

        public Persona GetPerson(int id)
        {
            Persona? persona = new Persona();
            persona = _context.Personas.Include(x => x.Empleado)
                                        .ThenInclude(y => y.ActivoEmpleado)
                                        .ThenInclude(xy => xy.Activo)
                                        .FirstOrDefault(e => e.Id_Empleado == id);
            if(persona != null) {
                if (persona.Empleado.Persona != null)
                    persona.Empleado.Persona = null;

                if (persona.Empleado.ActivoEmpleado != null)
                    persona.Empleado.ActivoEmpleado.Empleado = null;
            }

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
            var entity = GetPerson(id);

            if(request.Nombre != null)
                entity.Nombre = request.Nombre;

            if(!request.Apellidos.IsNullOrEmpty())
                entity.Apellidos = request.Apellidos;

            if(request.CURP != null)
                entity.CURP = request.CURP;

            if(request.Email != null)
                entity.Email = request.Email;

            if(request.FechaNacimiento != null)
                entity.FechaNacimiento = request.FechaNacimiento;

            if(request.NumEmpleado != null)
                entity.Empleado.NumEmpleado = request.NumEmpleado;

            if(request.Estatus != null)
                entity.Empleado.Estatus = request.Estatus;

            if(request.FechaIngreso != null)
                entity.Empleado.FechaIngreso = request.FechaIngreso;

            _context.Personas.Update(entity);
            _context.SaveChanges();
            return entity;
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
            if (activoEmplado.IdEmpleado == person.Id_Empleado) {
                activoEmplado = _context.ActivosEmpleados.FirstOrDefault(e => e.IdEmpleado == person.Id_Empleado);
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
