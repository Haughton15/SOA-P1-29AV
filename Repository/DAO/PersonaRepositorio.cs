using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Empleado GetPerson(string correo)
        {
            Empleado? empleado = new Empleado();
            empleado = _context.Empleados.Where(e => e.NumEmpleado == 1).FirstOrDefault();
            return empleado;
        }

        public Empleado RegisterEmpleado(PostEmpleadoRequest request)
        {

            Empleado empleado = new Empleado
            {
                NumEmpleado = request.NumEmp,
                Estatus = request.Estatus,
                FechaIngreso = request.FechaIngreso
            };
            Console.WriteLine("Register empleado");
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            Console.WriteLine("Save empleado");
            //Cambiar el siguiente a el ultimo guardado
            empleado = _context.Empleados.Where(e => e.NumEmpleado == request.NumEmp).FirstOrDefault();

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
