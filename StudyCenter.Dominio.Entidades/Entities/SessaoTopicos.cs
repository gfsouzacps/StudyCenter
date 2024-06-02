using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudyCenter.Dominio.Entidades.Entities;

public partial class SessaoTopicos
{
    public int IdSessaoTopico { get; set; }
    public int IdSessao { get; set; }
    public int IdTopico { get; set; }
    public decimal? DuracaoEstudo { get; set; }
    public virtual ICollection<AnotacoesTopicos> AnotacoesTopicos { get; set; } = new List<AnotacoesTopicos>();
    [JsonIgnore]
    public virtual Sessoes IdSessaoNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Topicos IdTopicoNavigation { get; set; } = null!;
}
