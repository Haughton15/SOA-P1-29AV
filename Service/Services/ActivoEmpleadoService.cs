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
using Azure;

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
            bool response = false;
            try
            {
                var activoEmpleadoExist = GetActivoEmpleado(id);
                if (activoEmpleadoExist == null)
                    throw new DirectoryNotFoundException("No se encontro el ActivoEmpleado con ese Id");

                response = activoEmpleadoRepository.DeleteActivoEmpleado(id);
            } catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            
            return response;
        }

        public ActivoEmpleado GetActivoEmpleado(int id)
        {
            var response = activoEmpleadoRepository.GetActivoEmpleado(id);
            return response;
        }

        public ActivoEmpleado PatchActivoEmpleado(int id, PatchActivoEmpleado request)
        {
            ActivoEmpleado response = new ActivoEmpleado();
            try
            {
                var activoEmpleadoExist= GetActivoEmpleado(id);
                if (activoEmpleadoExist == null)
                    throw new DirectoryNotFoundException("No se encontro el ActivoEmpleado con ese Id");

                response = activoEmpleadoRepository.PatchActivoEmpleado(id, request);
                
            } catch (Exception e) {
                _logger.LogError(e.Message);
            }
            return response;
        }

        public List<ActivoEmpleado> GetActivosEmpleadosEntrega()
        {
            var response = activoEmpleadoRepository.GetActivosEmpleadosEntrega();
            return response;
        }
    }
}
