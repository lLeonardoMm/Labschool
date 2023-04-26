namespace Leonardo.LabschoolProjeto.Controllers.Dto
{
    public class AtendimentoDto
    {
        public int codigoAluno { get; set; }
        public int codigoPedagogo { get; set; }
    }
    public class SaidaAlunoAtendimentoDto
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public DateTime dataNascimento { get; set; }
        public string cpf { get; set; }
        public string situacao { get; set; }
        public float nota { get; set; }
        public int atendimentos { get; set; }
        public int codigoPedagogo { get; set; }
        public string nomePedagogo { get; set; }
        public string telefonePedagogo { get; set; }
        public DateTime dataNascimentoPedagogo { get; set; }
        public string cpfPedagogo { get; set; }
        public int atendimentosPedagogo { get; set; }
    }

}
