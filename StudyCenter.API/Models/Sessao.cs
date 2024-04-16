using System;
using System.Collections.Generic;

namespace StudyCenter.API.Models;

public partial class Sessao
{
    public int IdSessao { get; set; }

    public string? NomeSessao { get; set; }

    public string? AnotacaoSessao { get; set; }

    public DateTime DthrInicioSessao { get; set; }

    public DateTime DthrFimSessao { get; set; }

    public virtual ICollection<SessaoTopico> SessaoTopicos { get; set; } = new List<SessaoTopico>();
}
