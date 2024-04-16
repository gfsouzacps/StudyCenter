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
    public virtual ICollection<Topico> Topicos { get; set; } = new List<Topico>();
}
