using Leonardo.LabschoolProjeto.Repository.IntarfaceRepository;
using Microsoft.AspNetCore.Mvc;

namespace Leonardo.LabschoolProjeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var professor = _professorRepository.ObterLista();


            return Ok(professor);
        }
    }
}
