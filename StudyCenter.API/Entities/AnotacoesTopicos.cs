using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudyCenter.API.Models;

public partial class AnotacoesTopicos
{
    public AnotacoesTopicos(int idAnotacaoTopico, int idSessaoTopico, string? anotacao)
    {
        IdAnotacaoTopico = idAnotacaoTopico;
        IdSessaoTopico = idSessaoTopico;
        Anotacao = anotacao;
    }
    public int IdAnotacaoTopico { get; set; }
    public int IdSessaoTopico { get; set; }
    public string? Anotacao { get; set; }

    [JsonIgnore]
    public virtual SessaoTopicos IdSessaoTopicoNavigation { get; set; } = null!;
}
