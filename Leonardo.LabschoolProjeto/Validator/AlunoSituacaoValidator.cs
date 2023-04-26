using FluentValidation;
using Leonardo.LabschoolProjeto.Controllers.Dto;

namespace LabSchool.Validator
{
    public class AlunoSituacaoValidator : AbstractValidator<AlunoSituacaoDto>
    {
        public AlunoSituacaoValidator()
        {
            RuleFor(a => a.Situacao).NotEmpty().WithMessage("Por favor inserir algum campo").NotNull().WithMessage("O valor não pode ser nulo")
                .Must(ValidatorDosNomes).WithMessage("Por Favor inserir apenas Ativo, Irregular ou Inativo");
        }
        public static bool ValidatorDosNomes(string nomes)
        {
            if (nomes == "Inativo" || nomes == "Ativo" || nomes == "Irregular")
            {
                return true;
            }
            else { return false; }
        }
    }
}
