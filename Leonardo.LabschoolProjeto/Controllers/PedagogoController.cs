using Leonardo.LabschoolProjeto.Controllers.Dto;
using Leonardo.LabschoolProjeto.Models;
using Leonardo.LabschoolProjeto.Repository.IntarfaceRepository;
using Microsoft.AspNetCore.Mvc;

namespace Leonardo.LabschoolProjeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedagogoController : ControllerBase
    {
        private readonly IPedagogoRepository _pedagogoRepository;

        public PedagogoController(IPedagogoRepository pedagogoRepository)
        {
            _pedagogoRepository = pedagogoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var pedagogo = _pedagogoRepository.ObterLista();

            return Ok(pedagogo);
        }
    }
}