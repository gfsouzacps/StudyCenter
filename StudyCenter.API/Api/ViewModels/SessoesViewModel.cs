using StudyCenter.API.Models;
using System.Text.Json.Serialization;

namespace StudyCenter.API.Api.ViewModels
{
    public class SessoesViewModel
    {
        [JsonIgnore]    
        public int IdSessao { get; set; }
        public string? NomeSessao { get; set; }
        public string? AnotacaoSessao { get; set; }
        public DateTime DthrInicioSessao { get; set; }
        public DateTime DthrFimSessao { get; set; }
        [JsonIgnore]
        public virtual ICollection<SessoesTopicos> SessaoTopicos { get; set; } = new List<SessoesTopicos>();
    }
}
