using System.Collections.Generic;
using System.Linq;
using Leonardo.LabschoolProjeto.Controllers.Dto;
using Leonardo.LabschoolProjeto.Repository.IntarfaceRepository;
using Microsoft.AspNetCore.Mvc;

namespace Leonardo.LabschoolProjeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtendimentoController : ControllerBase
    {
        private readonly IPedagogoRepository _pedagogoRepository;
        private readonly IAlunoRepository _alunoRepository;

        public AtendimentoController(IPedagogoRepository pedagogoRepository, IAlunoRepository alunoRepository)
        {
            _pedagogoRepository = pedagogoRepository;
            _alunoRepository = alunoRepository;
        }

        [HttpPut]

        public IActionResult Atendimento([FromBody] AtendimentoDto dto)
        {
            var aluno = _alunoRepository.ObeterPorId(dto.codigoAluno);
            var pedagogo = _pedagogoRepository.ObeterPorId(dto.codigoPedagogo);

            if (aluno == null || pedagogo == null)
            {
                return NotFound($"Algum codigo não existe, por favor informar ambos codigos válidos");
            }

            if (aluno.SituacaoDaMatricula == "ATENDIMENTO_PEDAGOGICO")
            {
                return BadRequest("O aluno já esta em atendimento pedagogico");
            }

            aluno.SituacaoDaMatricula = "ATENDIMENTO_PEDAGOGICO";
            aluno.QtdAtendimentos += 1;

            _alunoRepository.Atualizar(aluno);

            pedagogo.QtdAtendimento += 1;
            _pedagogoRepository.Atualizar(pedagogo);

            var saidaAlunoAtendimento = new SaidaAlunoAtendimentoDto()
            {
                codigo = aluno.Codigo,
                nome = aluno.Nome,
                telefone = aluno.Telefone,
                dataNascimento = aluno.DataDeNascimento,
                cpf = aluno.Cpf,
                situacao = aluno.SituacaoDaMatricula,
                nota = aluno.Nota,
                atendimentos = aluno.QtdAtendimentos,
                codigoPedagogo = pedagogo.Codigo,
                nomePedagogo = pedagogo.Nome,
                telefonePedagogo = pedagogo.Telefone,
                dataNascimentoPedagogo = pedagogo.DataDeNascimento,
                cpfPedagogo = pedagogo.Cpf,
                atendimentosPedagogo = pedagogo.QtdAtendimento

            };


            return Ok(saidaAlunoAtendimento);
        }
    }
}
