namespace Leonardo.LabschoolProjeto.Controllers.Dto
{
    public class AlunoCriacaoDto
    {
        public string nome { get; set; }
        public string telefone { get; set; }
        public DateTime dataNascimento { get; set; }
        public string cpf { get; set; }
        public string situacao { get; set; }
        public float nota { get; set; }
    }

    public class AlunoSituacaoDto
    {
        public string Situacao { get; set; }
    }
    public class AlunoSaidaDto
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public DateTime dataNascimento { get; set; }
        public string cpf { get; set; }
        public string situacao { get; set; }
        public float nota { get; set; }
        public int atendimentos { get; set; }
    }
    public class PedagogoCriacaodto
    {
        public string nome { get; set; }
        public string telefone { get; set; }
        public DateTime dataNascimento { get; set; }
        public string cpf { get; set; }
        public int TotalDeAtendimento { get; set; } = 0;

    }

}
