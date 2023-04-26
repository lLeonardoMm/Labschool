using System;
using System.Collections.Generic;

namespace Leonardo.LabschoolProjeto.Models;

public partial class Aluno : Pessoa
{
    public string SituacaoDaMatricula { get; set; }

    public float Nota { get; set; }

    public int QtdAtendimentos { get; set; }
}
