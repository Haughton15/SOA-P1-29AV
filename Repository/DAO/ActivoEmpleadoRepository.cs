using Azure.Core;
using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class ActivoEmpleadoRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivoEmpleadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActivoEmpleado GetActivoEmpleado(int id)
        {
            var response = _context.ActivosEmpleados.FirstOrDefault(e => e.Id == id);
            return response;
        }

        public ActivoEmpleado GetActivoEmpleadoByIdEmpleado(int id)
        {
            var response = _context.ActivosEmpleados.Include(y => y.Activo).FirstOrDefault(x => x.IdPersona == id);

            return response;
        }

        public bool DeleteActivoEmpleado(int id)
        {
            var found = GetActivoEmpleado(id);
            if (found == null)
            {
                return false;
            }
            ActivoEmpleado? activoEmpleado = new ActivoEmpleado();
            activoEmpleado = _context.ActivosEmpleados.FirstOrDefault(e => e.Id == id);

            Activo activo = _context.Activos.FirstOrDefault(e => e.Id == activoEmpleado.IdActivo);
            activo.Estatus = false;
            _context.ActivosEmpleados.Remove(activoEmpleado);
            _context.SaveChanges();
            return true;
        }


        public ActivoEmpleado CreateActivoEmpleado(PostActivoEmpleado request)
        {

            ActivoEmpleado activoEmpleado = new ActivoEmpleado
            {
                IdPersona = request.id_empleado,
                IdActivo = request.id_activo,
                FechaAsignacion = DateTime.Today,
                FechaEntrega = request.FechaEntrega,
                FechaLiberacion = request.FechaLiberacion
            };

            Activo activo = _context.Activos.FirstOrDefault(e => e.Id == request.id_activo);
            activo.Estatus = true;

            Console.WriteLine("Register empleado");
            _context.ActivosEmpleados.Add(activoEmpleado);
            _context.SaveChanges();
            Console.WriteLine("Save empleado");
            return activoEmpleado;
        }

        public ActivoEmpleado PatchActivoEmpleado(int id, PatchActivoEmpleado request)
        {
            var entity = GetActivoEmpleado(id);
            DateTime defaultDate = new DateTime(1, 1, 1);
            if (request.FechaLiberacion != defaultDate);
            entity.FechaLiberacion = request.FechaLiberacion;

            if(request.FechaEntrega != defaultDate)
            entity.FechaEntrega = request.FechaEntrega;

            _context.ActivosEmpleados.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<ActivoEmpleado> GetActivosEmpleadosEntrega()
        {

            List<ActivoEmpleado> activoEmpleados = new List<ActivoEmpleado>();
            activoEmpleados = _context.ActivosEmpleados.Include(y => y.Persona).ToList();

            return activoEmpleados;
        }
    }
}
