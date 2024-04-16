using System;
using System.Collections.Generic;

namespace StudyCenter.API.Models;

public partial class Materias
{
    public int IdMateria { get; set; }

    public string NomeMateria { get; set; } = null!;

    public virtual ICollection<Topico> Topicos { get; set; } = new List<Topico>();
}
