using System.Text.Json.Serialization;

namespace StudyCenter.Dominio.Entidades.ViewModels
{
    public class SessoesViewModel
    {
        [JsonIgnore]
        public int IdSessao { get; set; }
        public string? NomeSessao { get; set; }
        public string? AnotacaoSessao { get; set; }
        public DateTime DthrInicioSessao { get; set; }
        public DateTime DthrFimSessao { get; set; }
        public virtual ICollection<SessaoTopicosViewModel> SessaoTopicos { get; set; } = new List<SessaoTopicosViewModel>();
    }
}
