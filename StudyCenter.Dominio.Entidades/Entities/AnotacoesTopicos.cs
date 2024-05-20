using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudyCenter.Dominio.Entidades.Entities;

public partial class AnotacoesTopicos
{
    public int IdAnotacaoTopico { get; }
    public int IdSessaoTopico { get; set; }
    public string? Anotacao { get; set; }

    [JsonIgnore]
    public virtual SessaoTopicos IdSessaoTopicoNavigation { get; set; } = null!;
}
