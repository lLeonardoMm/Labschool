using Leonardo.LabschoolProjeto.Controllers.Dto;
using Leonardo.LabschoolProjeto.Models;
using Leonardo.LabschoolProjeto.Repository.IntarfaceRepository;
using Microsoft.AspNetCore.Mvc;

namespace Leonardo.LabschoolProjeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpPost]

        public IActionResult Creat([FromBody] AlunoCriacaoDto dto)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var alunoCpf = _alunoRepository.ObterLista();

            if (alunoCpf.Any(a => a.Cpf == dto.cpf))
            {
                return Conflict("Cpf já cadastrado");
            }

            var aluno = new Aluno()
            {
                Nome = dto.nome,
                Telefone = dto.telefone,
                DataDeNascimento = dto.dataNascimento,
                Cpf = dto.cpf,
                SituacaoDaMatricula = dto.situacao,
                Nota = dto.nota,
            };

            _alunoRepository.Adcionar(aluno);

            var alunoSaida = new AlunoSaidaDto()
            {
                codigo = aluno.Codigo,
                nome = aluno.Nome,
                telefone = aluno.Telefone,
                dataNascimento = aluno.DataDeNascimento,
                cpf = aluno.Cpf,
                situacao = aluno.SituacaoDaMatricula,
                nota = aluno.Nota,
                atendimentos = aluno.QtdAtendimentos
            };

            return CreatedAtAction(nameof(AlunoController.Get), new { codigo = aluno.Codigo }, alunoSaida);
        }

        [HttpPut]
        [Route("{codigo}")]
        public IActionResult Uptade(int codigo, [FromBody] AlunoSituacaoDto dto)
        {
            var aluno = _alunoRepository.ObeterPorId(codigo);

            if (aluno == null)
            {
                return NotFound($"O codigo {codigo} não existe, por favor informar um codigo válido");
            }

            aluno.SituacaoDaMatricula = dto.Situacao;

            _alunoRepository.Atualizar(aluno);

            var alunoSaida = new AlunoSaidaDto()
            {
                codigo = aluno.Codigo,
                nome = aluno.Nome,
                telefone = aluno.Telefone,
                dataNascimento = aluno.DataDeNascimento,
                cpf = aluno.Cpf,
                situacao = aluno.SituacaoDaMatricula,
                nota = aluno.Nota,
                atendimentos = aluno.QtdAtendimentos
            };

            return CreatedAtAction(nameof(AlunoController.Get), new { codigo = aluno.Codigo }, alunoSaida);
        }

        [HttpGet]
        public IActionResult Get(string? situacao)
        {

            var alunos = _alunoRepository.ObterListaFiltro(situacao);

            return Ok(alunos);
        }

        [HttpGet]
        [Route("{codigo}")]
        public IActionResult Get([FromRoute] int codigo)
        {
            var aluno = _alunoRepository.ObeterPorId(codigo);

            if (aluno == null)
            {
                return NotFound($"O codigo {codigo} não existe, por favor informar um codigo válido");
            }
            return Ok(aluno);
        }

        [HttpDelete]
        [Route("{codigo}")]

        public IActionResult Delete([FromRoute] int codigo)
        {
            var estudante = _alunoRepository.ObeterPorId(codigo);
            if (estudante == null)
            {
                return NotFound($"O codigo {codigo} já não existe");
            }
            _alunoRepository.Excluir(codigo);
            return NoContent();
        }
    }
}
