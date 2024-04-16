using System;
using System.Collections.Generic;

namespace StudyCenter.API.Models;

public partial class SessaoTopico
{
    public int IdSessaoTopico { get; set; }

    public int IdSessao { get; set; }

    public int IdTopico { get; set; }

    public decimal? DuracaoEstudo { get; set; }

    public virtual ICollection<AnotacoesTopico> AnotacoesTopicos { get; set; } = new List<AnotacoesTopico>();

    public virtual Sessao IdSessaoNavigation { get; set; } = null!;

    public virtual Topico IdTopicoNavigation { get; set; } = null!;
}
