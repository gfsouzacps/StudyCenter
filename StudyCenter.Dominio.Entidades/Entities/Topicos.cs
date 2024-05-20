﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudyCenter.Dominio.Entidades.Entities;

public partial class Topicos
{
    public Topicos(int idTopico, string nomeTopico, int? idMateria)
    {
        IdTopico = idTopico;
        NomeTopico = nomeTopico;
        IdMateria = idMateria;
    }
    public int IdTopico { get; set; }
    public string NomeTopico { get; set; } = null!;
    public int? IdMateria { get; set; }

    [JsonIgnore]
    public virtual Materias? IdMateriaNavigation { get; set; }

    public virtual ICollection<SessaoTopicos> SessaoTopicos { get; set; } = new List<SessaoTopicos>();
}
