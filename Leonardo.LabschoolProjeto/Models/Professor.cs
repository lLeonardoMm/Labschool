using System;
using System.Collections.Generic;

namespace Leonardo.LabschoolProjeto.Models;

public partial class Professor : Pessoa
{
    public string Estado { get; set; } = null!;

    public string Experiencia { get; set; } = null!;

    public string FormacaoAcademica { get; set; } = null!;
}
