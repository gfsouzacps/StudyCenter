using System;
using System.Collections.Generic;

namespace StudyCenter.API.Models;

public partial class SessaoTopicos
{
    public SessaoTopicos(int idSessaoTopico, int idSessao, int idTopico, decimal? duracaoEstudo)
    {
        IdSessaoTopico = idSessaoTopico;
        IdSessao = idSessao;
        IdTopico = idTopico;
        DuracaoEstudo = duracaoEstudo;
    }
    public int IdSessaoTopico { get; set; }

    public int IdSessao { get; set; }

    public int IdTopico { get; set; }

    public decimal? DuracaoEstudo { get; set; }

    public virtual ICollection<AnotacoesTopicos> AnotacoesTopicos { get; set; } = new List<AnotacoesTopicos>();

    public virtual Sessoes IdSessaoNavigation { get; set; } = null!;

    public virtual Topicos IdTopicoNavigation { get; set; } = null!;
}
