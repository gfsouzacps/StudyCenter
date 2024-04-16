using System;
using System.Collections.Generic;

namespace StudyCenter.API.Models;

public partial class Topicos
{
    public int IdTopico { get; set; }

    public string Topico1 { get; set; } = null!;

    public int? IdMateria { get; set; }

    public virtual Materias? IdMateriaNavigation { get; set; }

    public virtual ICollection<SessoesTopicos> SessaoTopicos { get; set; } = new List<SessoesTopicos>();
}
