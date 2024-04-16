using System;
using System.Collections.Generic;

namespace StudyCenter.API.Models;

public partial class AnotacoesTopico
{
    public int IdAnotacao { get; set; }

    public int IdSessaoTopico { get; set; }

    public string? Anotacao { get; set; }

    public virtual SessaoTopico IdSessaoTopicoNavigation { get; set; } = null!;
}
