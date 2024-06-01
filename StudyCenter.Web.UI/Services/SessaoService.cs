using Entidades = StudyCenter.Dominio.Entidades.Entities;
using StudyCenter.Web.UI.Components.Pages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


public class SessaoService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public SessaoService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<Entidades.Sessoes[]> GetSessoesAsync()
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Sessoes/GetSessao";
        return await _httpClient.GetFromJsonAsync<Entidades.Sessoes[]>(url);
    }
}