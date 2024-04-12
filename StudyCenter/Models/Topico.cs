using System;
using System.Collections.Generic;

namespace StudyCenter.Models;

public partial class Topico
{
    public int IdTopico { get; set; }

    public string Topico1 { get; set; } = null!;

    public int? IdMateria { get; set; }

    public virtual Materia? IdMateriaNavigation { get; set; }

    public virtual ICollection<SessaoTopico> SessaoTopicos { get; set; } = new List<SessaoTopico>();
}
