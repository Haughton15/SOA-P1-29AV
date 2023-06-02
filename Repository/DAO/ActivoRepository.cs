using Domain.Entities;
using Domain.Models.Requests;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class ActivoRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Activo> GetActivos()
        {
            List<Activo> lista = new List<Activo>();

            lista = _context.Activos.Where(x => x.Estatus != true).ToList();

            return lista;
        }

        public Activo RegisterActivo(PostActivoRequest request)
        {
            Activo response = new Activo
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Estatus = false
            };
            _context.Activos.Add(response);
            _context.SaveChanges();
            response = _context.Activos.Where(e => e.Nombre == request.Nombre).FirstOrDefault();
            return response;
        }
    }
}
