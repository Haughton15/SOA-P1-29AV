using Microsoft.Extensions.Logging;
using Repository.DAO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Context;
using Domain.Entities;
using Domain.Models.Requests;
using Azure.Core;

namespace Service.Services
{
    public class ActivoEmpleadoService : IActivoEmpleado
    {

        private readonly ILogger<ActivoEmpleadoService> _logger;
        public readonly ActivoEmpleadoRepository activoEmpleadoRepository;

        public ActivoEmpleadoService(ILogger<ActivoEmpleadoService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            activoEmpleadoRepository = new ActivoEmpleadoRepository(context);
        }

        public ActivoEmpleado CreateActivoEmpleado(PostActivoEmpleado request)
        {
            var response = activoEmpleadoRepository.CreateActivoEmpleado(request);
            return response;
        }

        public bool DeleteActivoEmpleado(int id)
        {
            GetActivoEmpleado(id);
            var response = activoEmpleadoRepository.DeleteActivoEmpleado(id);
            return response;
        }

        public ActivoEmpleado GetActivoEmpleado(int id)
        {
            var response = activoEmpleadoRepository.GetActivoEmpleado(id);
            return response;
        }

        public ActivoEmpleado PatchActivoEmpleado(int id, PatchActivoEmpleado request)
        {
            GetActivoEmpleado(id);
            var response = activoEmpleadoRepository.PatchActivoEmpleado(id, request);
            return response;
        }

        public List<ActivoEmpleado> GetActivosEmpleadosEntrega()
        {
            var response = activoEmpleadoRepository.GetActivosEmpleadosEntrega();
            return response;
        }
    }
}
