using Entidades = StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Web.UI.Components.Pages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


public class MateriaService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public MateriaService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<Entidades.Materias[]> GetMateriasAsync()
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Materias/GetMaterias";
        return await _httpClient.GetFromJsonAsync<Entidades.Materias[]>(url);
    }
}