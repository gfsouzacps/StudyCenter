using System;
using System.Collections.Generic;

namespace StudyCenter.API.Models;

public partial class AnotacoesTopicos
{
    public int IdAnotacao { get; set; }

    public int IdSessaoTopico { get; set; }

    public string? Anotacao { get; set; }

    public virtual SessoesTopicos IdSessaoTopicoNavigation { get; set; } = null!;
}
