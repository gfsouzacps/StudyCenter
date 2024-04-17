using StudyCenter.API.Models;
using System.Text.Json.Serialization;

namespace StudyCenter.API.Api.ViewModels
{
    public class TopicosViewModel
    {
        [JsonIgnore]
        public int IdTopico { get; set; }
        public string NomeTopico { get; set; } = null!;
        public int IdMateria { get; set; }
    }
}
