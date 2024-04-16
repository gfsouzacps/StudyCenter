﻿using System;
using System.Collections.Generic;

namespace StudyCenter.API.Models;

public partial class Sessoes
{
    public Sessoes(int idSessao, string? nomeSessao, string? anotacaoSessao, DateTime dthrInicioSessao, DateTime dthrFimSessao) 
    {
        IdSessao = idSessao;
        NomeSessao = nomeSessao;
        AnotacaoSessao = anotacaoSessao;
        DthrInicioSessao = dthrInicioSessao;
        DthrFimSessao = dthrFimSessao;
    }

    public int IdSessao { get; set; }

    public string? NomeSessao { get; set; }

    public string? AnotacaoSessao { get; set; }

    public DateTime DthrInicioSessao { get; set; }

    public DateTime DthrFimSessao { get; set; }

    public virtual ICollection<SessoesTopicos> SessaoTopicos { get; set; } = new List<SessoesTopicos>();
}
