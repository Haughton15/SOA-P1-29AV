using Domain.Entities;
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

            lista = _context.Personas.ToList();

            return lista;
        }

        public List<Empleado> GetEmpleados()
        {
            List<Empleado> list = new List<Empleado>();

            list = _context.Empleados.Include(x => x.Area).ToList();

            return list;
        }

        public Empleado GetPerson(string correo)
        {
            Empleado? empleado = new Empleado();
            empleado = _context.Empleados.FirstOrDefault(e => e.Correo == correo);
            return empleado;
        }
    }
}
