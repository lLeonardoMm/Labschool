using Leonardo.LabschoolProjeto.Models;
using Leonardo.LabschoolProjeto.Repository.IntarfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace Leonardo.LabschoolProjeto.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly LabSchoolContexto _context;

        public ProfessorRepository(LabSchoolContexto context)
        {
            _context = context;
        }
        public List<Professor> ObterLista()
        {
            return _context.Professores.ToList();
        }
    }
}
