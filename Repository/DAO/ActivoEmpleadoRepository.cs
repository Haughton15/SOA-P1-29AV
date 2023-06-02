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

        public bool DeleteActivoEmpleado(int id)
        {
            var found = GetActivoEmpleado(id);
            if (found == null)
            {
                return false;
            }
            ActivoEmpleado? activoEmpleado = new ActivoEmpleado();
            activoEmpleado = _context.ActivosEmpleados.FirstOrDefault(e => e.Id == id);   
            _context.ActivosEmpleados.Remove(activoEmpleado);
            Activo activo = _context.Activos.FirstOrDefault(e => e.Id == request.id_activo);
            activo.Estatus = false;
            _context.SaveChanges();
            return true;
        }


        public ActivoEmpleado CreateActivoEmpleado(PostActivoEmpleado request)
        {

            ActivoEmpleado activoEmpleado = new ActivoEmpleado
            {
                IdEmpleado = request.id_empleado,
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
            //Cambiar el siguiente a el ultimo guardado
            activoEmpleado = _context.ActivosEmpleados.Where(e => e.IdEmpleado == request.id_empleado).FirstOrDefault();
            return activoEmpleado;
        }

        public ActivoEmpleado PatchActivoEmpleado(int id, PatchActivoEmpleado request)
        {
            var entity = GetActivoEmpleado(id);
            if(request.FechaLiberacion != null)
            entity.FechaLiberacion = request.FechaLiberacion;

            if(request.FechaEntrega != null)
            entity.FechaEntrega = request.FechaEntrega;

            _context.ActivosEmpleados.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<ActivoEmpleado> GetActivosEmpleadosEntrega()
        {

            List<ActivoEmpleado> activoEmpleados = new List<ActivoEmpleado>();
            activoEmpleados = _context.ActivosEmpleados.Include(x => x.Empleado).ThenInclude(y => y.Persona).ToList();

            return activoEmpleados;
        }
    }
}
