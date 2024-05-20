using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudyCenter.Dominio.Entidades.Entities;

public partial class Topicos
{
    public int IdTopico { get; }
    public string NomeTopico { get; set; } = null!;
    public int? IdMateria { get; set; }

    [JsonIgnore]
    public virtual Materias? IdMateriaNavigation { get; set; }

    public virtual ICollection<SessaoTopicos> SessaoTopicos { get; set; } = new List<SessaoTopicos>();
}
