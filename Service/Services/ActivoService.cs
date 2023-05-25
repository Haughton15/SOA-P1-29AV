using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.Extensions.Logging;
using Repository.DAO;
using Service.IServices;
using Repository.Context;

namespace Service.Services
{
    public class ActivoService : IActivo
    {

        private readonly ILogger<ActivoService> _logger;
        public readonly ActivoRepository activoRepository;

        public ActivoService(ILogger<ActivoService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            activoRepository = new ActivoRepository(context);
        }
        public List<Activo> GetActivosDisponibles()
        {
            throw new NotImplementedException();
        }

        public Activo RegisterActivo(PostActivoRequest request)
        {
            var response = activoRepository.RegisterActivo(request);
            return response;
        }
    }
}
