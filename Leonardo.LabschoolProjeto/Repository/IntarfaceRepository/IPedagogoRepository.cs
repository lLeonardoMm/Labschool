using Leonardo.LabschoolProjeto.Models;

namespace Leonardo.LabschoolProjeto.Repository.IntarfaceRepository
{
    public interface IPedagogoRepository
    {
        List<Pedagogo> ObterLista();
        Pedagogo ObeterPorId(int id);
        void Atualizar(Pedagogo pedagogo);

    }
}
