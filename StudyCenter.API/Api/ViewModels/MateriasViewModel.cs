using StudyCenter.API.Models;
using System.Text.Json.Serialization;

namespace StudyCenter.API.Api.ViewModels
{
    public class MateriasViewModel
    {
        public MateriasViewModel() { }
        [JsonIgnore]
        public int IdMateria { get; set; }
        public string NomeMateria { get; set; }
        [JsonIgnore]
        public virtual ICollection<Topicos> Topicos { get; set; } = new List<Topicos>();
    }
}
