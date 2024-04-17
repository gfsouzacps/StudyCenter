using StudyCenter.API.Models;
using System.Text.Json.Serialization;

namespace StudyCenter.API.Api.ViewModels
{
    public class SessaoTopicosViewModel
    {
        [JsonIgnore]
        public int IdSessaoTopico { get; set; }
        [JsonIgnore]
        public int IdSessao { get; set; }
        public int IdTopico { get; set; }
        public decimal? DuracaoEstudo { get; set; }
        public virtual ICollection<AnotacoesTopicosViewModel> AnotacoesTopicos { get; set; } = new List<AnotacoesTopicosViewModel>();
    }
}
