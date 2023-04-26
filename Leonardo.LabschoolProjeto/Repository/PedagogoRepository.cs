using Leonardo.LabschoolProjeto.Models;
using Leonardo.LabschoolProjeto.Repository.IntarfaceRepository;

namespace Leonardo.LabschoolProjeto.Repository
{
    public class PedagogoRepository : IPedagogoRepository
    {
        private readonly LabSchoolContexto _context;

        public PedagogoRepository(LabSchoolContexto context)
        {
            _context = context;
        }

        public Pedagogo? ObeterPorId(int codigo)
        {
            return _context.Pedagogos.FirstOrDefault(e => e.Codigo.Equals(codigo));

        }

        public List<Pedagogo> ObterLista()
        {
            return _context.Pedagogos.ToList();

        }
        public void Atualizar(Pedagogo pedagogos)
        {
            _context.Pedagogos.Update(pedagogos);
            _context.SaveChanges();
        }
    }
}
