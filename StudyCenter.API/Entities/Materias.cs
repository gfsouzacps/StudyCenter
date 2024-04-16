using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudyCenter.API.Models;

public partial class Materias
{
    public Materias(int idMateria, string nomeMateria) 
    {
        IdMateria = idMateria;
        NomeMateria = nomeMateria;
    }

    public int IdMateria { get; set; }
    public string NomeMateria { get; set; } = null!;
    public virtual ICollection<Topicos> Topicos { get; set; } = new List<Topicos>();
}
