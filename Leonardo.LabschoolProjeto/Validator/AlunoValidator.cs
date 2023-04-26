using FluentValidation;
using Leonardo.LabschoolProjeto.Controllers.Dto;

namespace LabSchool.Validator
{
    public class AlunoValidator : AbstractValidator<AlunoCriacaoDto>
    {
        public AlunoValidator()
        {
            RuleFor(a => a.situacao).NotEmpty().NotNull().Must(ValidatorDosNomes).WithMessage("Por Favor inserir apenas Ativo, Irregular ou Inativo");
            RuleFor(a => a.nota).NotEmpty().NotNull().Must(NotaValidator).WithMessage("A nota tem que ser maior ou igual a zero(0) e menor ou igual a dez(10)");
            RuleFor(a => a.nome).NotEmpty().NotNull();
            RuleFor(a => a.telefone).NotEmpty().NotNull();
            RuleFor(a => a.cpf).NotEmpty().NotNull().Must(Cpf).WithMessage("Por favor inclua um cpf válido");
            RuleFor(a => a.dataNascimento).NotEmpty().NotNull();
        }

        public static bool ValidatorDosNomes(string nomes)
        {
            if (nomes == "Inativo" || nomes == "Ativo" || nomes == "Irregular")
            {
                return true;
            }
            else { return false; }
        }

        public static bool NotaValidator (float nota)
        {
            if (nota < 0 || nota > 10)
            {
                return false;
            }
            else { return true; }
        }
        public static bool Cpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);

        }
    }


}
