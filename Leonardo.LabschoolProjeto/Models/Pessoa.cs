namespace Leonardo.LabschoolProjeto.Models
{
    public class Pessoa
    {
        public int Codigo { get; set; }

        public string Nome { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public DateTime DataDeNascimento { get; set; }

        public string Cpf { get; set; } = null!;
    }
}
