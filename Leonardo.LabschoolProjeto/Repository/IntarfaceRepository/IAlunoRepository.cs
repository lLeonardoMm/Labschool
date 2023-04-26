using Leonardo.LabschoolProjeto.Models;

namespace Leonardo.LabschoolProjeto.Repository.IntarfaceRepository
{
    public interface IAlunoRepository
    {
        void Adcionar(Aluno aluno);
        List<Aluno> ObterLista();
        List<Aluno> ObterListaFiltro(string filtro);
        Aluno ObeterPorId(int codigo);
        void Atualizar(Aluno aluno);
        void Excluir(int codigo);
    }
}
