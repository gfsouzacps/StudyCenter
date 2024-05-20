using System.Text.Json.Serialization;

namespace StudyCenter.Dominio.Entidades.ViewModels
{
    public class TopicosViewModel
    {
        [JsonIgnore]
        public int IdTopico { get; set; }
        public string NomeTopico { get; set; } = null!;
        [JsonIgnore]
        public int IdMateria { get; set; }
    }
}
