using Leonardo.LabschoolProjeto.Models;
using Leonardo.LabschoolProjeto.Repository.IntarfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace Leonardo.LabschoolProjeto.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly LabSchoolContexto _context;

        public AlunoRepository(LabSchoolContexto context)
        {
            _context = context;
        }
        public void Adcionar(Aluno codigo)
        {
            _context.Alunos.Add(codigo);
            _context.SaveChanges();
        }

        public void Atualizar(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }

        public void Excluir(int codigo)
        {
            var aluno = ObeterPorId(codigo);
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }

        public Aluno? ObeterPorId(int codigo)
        {
            return _context.Alunos.FirstOrDefault(e => e.Codigo.Equals(codigo));
        }

        public List<Aluno> ObterLista()
        {
            return _context.Alunos.ToList();
        }
        public List<Aluno> ObterListaFiltro(string filtro)
        {
            if (string.IsNullOrEmpty(filtro))
            {
                return _context.Alunos.ToList();
            }
            else { return _context.Alunos.Where(x => x.SituacaoDaMatricula.Contains(filtro)).ToList(); }
        }
    }
}
