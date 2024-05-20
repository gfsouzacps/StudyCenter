using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudyCenter.Dominio.Entidades.Entities;

public partial class Materias
{
    public int IdMateria { get; }
    public string NomeMateria { get; set; } = null!;
    public virtual ICollection<Topicos> Topicos { get; set; } = new List<Topicos>();
}
