using System.Text.Json.Serialization;

namespace StudyCenter.Dominio.Entidades.ViewModels
{
    public class MateriasViewModel
    {
        [JsonIgnore]
        public int IdMateria { get; set; }
        public string NomeMateria { get; set; }
        public virtual ICollection<TopicosViewModel> Topicos { get; set; } = new List<TopicosViewModel>();
    }
}
