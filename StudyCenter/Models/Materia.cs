using System;
using System.Collections.Generic;

namespace StudyCenter.Models;

public partial class Materia
{
    public int IdMateria { get; set; }

    public string NomeMateria { get; set; } = null!;

    public virtual ICollection<Topico> Topicos { get; set; } = new List<Topico>();
}
