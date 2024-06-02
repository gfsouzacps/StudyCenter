using StudyCenter.Dominio.Entidades.ViewModels;
using Entidade = StudyCenter.Dominio.Entidades.Entities;
public class SessaoService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public SessaoService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<Entidade.Sessoes[]> GetSessoesAsync()
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Sessoes";
        return await _httpClient.GetFromJsonAsync<Entidade.Sessoes[]>(url);
    }

    public async Task<Entidade.Sessoes> CreateSessaoAsync(SessoesViewModel sessaoViewModel)
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Sessoes";
        var response = await _httpClient.PostAsJsonAsync(url, sessaoViewModel);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Entidade.Sessoes>();
    }

    public async Task<Entidade.Sessoes> UpdateSessaoAsync(int idSessao, SessoesViewModel sessaoViewModel)
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Sessoes/{idSessao}";
        var response = await _httpClient.PutAsJsonAsync(url, sessaoViewModel);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Entidade.Sessoes>();
    }

    public async Task DeleteSessaoAsync(int idSessao)
    {
        var apiUrl = _configuration["ApiSettings:BaseUrl"];
        var url = $"{apiUrl}Sessoes/{idSessao}";
        var response = await _httpClient.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
    }
}