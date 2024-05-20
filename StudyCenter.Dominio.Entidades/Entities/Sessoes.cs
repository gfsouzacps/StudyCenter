using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudyCenter.Dominio.Entidades.Entities;

public partial class Sessoes
{
    public int IdSessao { get; }
    public string? NomeSessao { get; set; }
    public string? AnotacaoSessao { get; set; }
    public DateTime DthrInicioSessao { get; set; }
    public DateTime DthrFimSessao { get; set; }
    public virtual ICollection<SessaoTopicos> SessaoTopicos { get; set; } = new List<SessaoTopicos>();
}
