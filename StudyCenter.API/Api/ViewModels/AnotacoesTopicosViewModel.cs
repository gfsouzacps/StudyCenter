using StudyCenter.API.Models;
using System.Text.Json.Serialization;

namespace StudyCenter.API.Api.ViewModels
{
    public class AnotacoesTopicosViewModel
    {
        [JsonIgnore]
        public int IdAnotacaoTopico { get; set; }
        [JsonIgnore]
        public int IdSessaoTopico { get; set; }

        public string? Anotacao { get; set; }
    }
}
